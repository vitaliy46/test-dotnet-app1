using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

// requires a reference to System.Web.dll

// requires a reference to System.Configuration.dll

/*
    Note that some project templates in Visual Studio default to build against Client Profile which does not pack System.Web.dll.
    Target the full .NET Framework or reference the assembly with a local copy from C:\Windows\Microsoft.NET\Framework64\v4.0.30319.
    See examples in comments at the end of this file.
    
    Patrick de Kleijn (info@patrick.nl), 2011
*/

namespace Kis.Noris.Api.Dao
{
    /// <summary>
    /// Static helper for opening provider agnostic ADO.NET database connections. Open a connection to any database
    /// and don't worry about what database was configured in app.config, web.config, settings.setting or xml store.
    /// Useful to target multiple databases without the hassle; SQL Server, SQL Lite, MySQL, Postgress and Firebird.
    /// I like to use it with a micro ORM like Dapper (http://code.google.com/p/dapper-dot-net/) to query databases.
    /// </summary>
    public static class Database
    {
        // Change this key for each project. We're using Triple DES for encrypting connectionstrings, but you easily
        // change the CryptoServiceProvider in Sources.EncryptConnectionString(). For Single DES the key needs fixed
        // size of 8 bytes. For Triple DES it is 24 (192bit). Rijndael supports 128, 192 and 256 bit keysizes.
        private const string encryptionkey = "02642974-49f4-B5F2-46AE-C0C98CF6EFCB"; // Just a GUID >= 24 characters.


        #region Open Connection

        /// <summary>
        /// Returns an open connection by its name from app.config, web.config, settings.settings or imported xml-store.
        /// </summary>
        /// <param name="connectionName">Name of connectionString setting in configuration store.</param>
        /// <returns>Returns a new instance of the provider's class that represents a connection to the database.</returns>
        /// <remarks>Please wrap in a using statement. It's best practice to close and dispose of database connections
        /// as soon as you're done with it. Connection pooling will kick in and take care of live connections for you.</remarks>
        public static DbConnection Open(string connectionName)
        {
            DbConnection connection = Connection(connectionName);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Imports an xml store (e.g. databases.xml) with connection settings and returns the requested connection opened.
        /// </summary>
        /// <param name="configurationFileName">Full or relative file path. (e.g. C:\databases.xml)</param>
        /// <param name="connectionName">Returns a new instance of the provider's class that represents a connection to the database.</param>
        /// <returns>Returns a new instance of the provider's class that represents a connection to the database.</returns>
        public static DbConnection Open(string configurationFileName, string connectionName)
        {
            DbConnection connection = Connection(configurationFileName, connectionName);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Imports an xml store by it's relative path in ASP.NET and returns the requested connection.
        /// Does not open the connection.
        /// </summary>
        /// <param name="httpContext">Context of HTTP request to resolve relative path with. (e.g. HttpContext.Current)</param>
        /// <param name="configurationFileName">Full or relative server path. (e.g. ~/App_Data/databases.xml)</param>
        /// <param name="connectionName">Returns a new instance of the provider's class that represents a connection to the database.</param>
        public static DbConnection Open(HttpContextBase httpContext, string configurationFileName, string connectionName)
        {
            DbConnection connection = Connection(httpContext, configurationFileName, connectionName);
            connection.Open();
            return connection;
        }

        #endregion Open

        #region Closed Connection

        /// <summary>
        /// Returns connection by its name from app.config, web.config, settings.settings or imported xml-store.
        /// Does not open the connection.
        /// </summary>
        /// <param name="connectionName">Name of connectionString setting in configuration store.</param>
        /// <returns>Returns a new instance of the provider's class that represents a connection to the database.</returns>
        /// <remarks>Please wrap in a using statement. It's best practice to close and dispose of database connections
        /// as soon as you're done with it. Connection pooling will kick in and take care of live connections for you.</remarks>
        public static DbConnection Connection(string connectionName)
        {
            Sources.Configuration configuration = Sources.Find(connectionName);
            DbConnection connection = configuration.Provider.CreateConnection();
            connection.ConnectionString = configuration.ConnectionString;
            return connection;
        }

        /// <summary>
        /// Imports an xml store (e.g. databases.xml) with connection settings and returns the requested connection.
        /// Does not open the connection.
        /// </summary>
        /// <param name="configurationFileName">Full or relative file path. (e.g. C:\databases.xml)</param>
        /// <param name="connectionName">Returns a new instance of the provider's class that represents a connection to the database.</param>
        /// <returns>Returns a new instance of the provider's class that represents a connection to the database.</returns>
        public static DbConnection Connection(string configurationFileName, string connectionName)
        {
            Sources.ImportXmlStore(configurationFileName);
            return Connection(connectionName);
        }

        /// <summary>
        /// Imports an xml store by it's relative path in ASP.NET and returns the requested connection.
        /// Does not open the connection.
        /// </summary>
        /// <param name="httpContext">Context of HTTP request to resolve relative path with. (e.g. HttpContext.Current)</param>
        /// <param name="configurationFileName">Full or relative server path. (e.g. ~/App_Data/databases.xml)</param>
        /// <param name="connectionName">Returns a new instance of the provider's class that represents a connection to the database.</param>
        /// <returns>Returns a new instance of the provider's class that represents a connection to the database.</returns>
        public static DbConnection Connection(HttpContextBase httpContext, string configurationFileName, string connectionName)
        {
            Sources.ImportXmlStore(httpContext.Server.MapPath(configurationFileName));
            return Connection(connectionName);
        }

        #endregion Closed Connection



        /// <summary>
        /// Keeps a collection of database sources settings from configuration files typically used in .NET applications.
        /// Additionally instantiates required data source provider classes and keeps those around until the app domain
        /// is unloaded or Database.Sources.Clear() is called and all dependent connections are closed and disposed of.
        /// </summary>
        public static class Sources
        {
            public class Configuration
            {
                // Reference to provider classes, instance is shared.
                public DbProviderFactory Provider { get; set; }

                // Settings from configuration files.
                public string Name { get; set; }
                public string ProviderName { get; set; }
                private string _connectionString = String.Empty;
                public string ConnectionString
                {
                    get
                    {
                        return _connectionString;
                    }

                    set
                    {
                        _connectionString = value.StartsWith("encrypted:") ? DecryptConnectionString(value) : value;
                    }

                }
            }

            private static Lazy<List<Configuration>> _configurations = new Lazy<List<Configuration>>();
            private static Lazy<List<string>> _xmlStores = new Lazy<List<string>>();
            private static Lazy<Dictionary<string, DbProviderFactory>> _providers = new Lazy<Dictionary<string, DbProviderFactory>>();

            /// <summary>
            /// Databases is a static helper class that keeps a reference to instantiated database providers once used. This means it
            /// keeps a couple of objects alive in memory while the assembly is loaded. That is potentially a behaviour you do not need
            /// or like. You can however flush all settings and references to instantiated providers by calling Clear() when done.
            /// Required data source providers will build again when you create a connection. But most projects are likely to create
            /// connections with the same provider classes continuesly (for new queries), which is especially true for web applications.
            /// </summary>
            public static void Clear()
            {
                if (_configurations.IsValueCreated) _configurations.Value.Clear();
                if (_xmlStores.IsValueCreated) _xmlStores.Value.Clear();
                if (_providers.IsValueCreated) _providers.Value.Clear();
            }

            /// <summary>
            /// Takes connection settings from a specified XML store (e.g. databases.xml) and includes those as database sources.
            /// Connection settings from web.config and app.config are retrieved by default with WebConfigurationManager. Stores
            /// are added once only, so there's no harm in calling this often. However, there is a some overhead in checking.
            /// </summary>
            /// <param name="configurationFileName">Path to XML store with database settings (e.g. "C:\\databases.xml").</param>
            internal static void ImportXmlStore(string configurationFileName)
            {
                if (!_xmlStores.Value.Contains(configurationFileName, StringComparer.CurrentCultureIgnoreCase))
                {
                    var doc = XDocument.Load(configurationFileName);
                    _configurations.Value.AddRange(doc.Root == null
                        ? Enumerable.Empty<Configuration>()
                        : (from databaseElement in doc.Root.Elements("database")
                           select new Configuration
                           {
                               Name = (string)databaseElement.Element("name"),
                               ConnectionString = (string)databaseElement.Element("connectionString"),
                               ProviderName = (string)databaseElement.Element("providerName"),
                               Provider = AddProvider((string)databaseElement.Element("providerName"))
                           })
                    );
                    _xmlStores.Value.Add(configurationFileName);
                }
            }

            /// <summary>
            /// Adds data source provider to a static dictionary to reuse the same factory for multiple connections.
            /// Returns an existing provider of the same class (e.g. MySql.Data.MySqlClient) if already instantiated.
            /// </summary>
            private static DbProviderFactory AddProvider(string providerName)
            {
                if (_providers.Value.ContainsKey(providerName))
                {
                    return _providers.Value[providerName];
                }
                else
                {
                    DbProviderFactory provider;
                    _providers.Value.Add(providerName, provider = DbProviderFactories.GetFactory(providerName));
                    return provider;
                }
            }

            /// <summary>
            /// Finds a single database source configuration by its name parameter in app.config, web.config, settings.settings
            /// and imported databases.xml stores.
            /// </summary>
            /// <returns>Returns a database configuration with instantiated data source provider.</returns>
            /// <exception cref="System.Configuration.ConfigurationErrorsException">Thrown when configuration not found.</exception>
            internal static Configuration Find(string name)
            {
                // Search configurations used and imported from xml stores.
                Configuration configuration = _configurations.Value.Find(c => c.Name == name);
                if (configuration != null) return configuration;
                // TODO: Search configurations in settings.setting.

                // Search configurations in web.config and <applicationname>.config.
                var newconfiguration = new Configuration()
                {
                    Name = name,
                    ConnectionString = WebConfigurationManager.ConnectionStrings[name].ConnectionString,
                    ProviderName = WebConfigurationManager.ConnectionStrings[name].ProviderName,
                    Provider = AddProvider(WebConfigurationManager.ConnectionStrings[name].ProviderName)
                };

                _configurations.Value.Add(newconfiguration);
                return newconfiguration;
            }


            /// <summary>
            /// Encrypts a connection string to use in datasource configs. See example in Databases.cs.
            /// </summary>
            /// <param name="connectionString">Server=localhost;User=myusername;Password=mypassword;Charser=NONE;Database=C:\Database.fdb</param>
            /// <returns>encrypted:0jx0NNG6POnEZ4/5VKXfeUj0u5WhEa9AEdPx7mYrIiFGmPNPJw8dVZvrcc8gjuy35mz/lt8M2s4e9dQFXHZzgQ##</returns>
            public static string EncryptConnectionString(string connectionString)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] tdesKey = encoding.GetBytes(encryptionkey.Substring(0, 24));
                byte[] passwordBytes = encoding.GetBytes(connectionString);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = tdesKey;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] passwordArray = cTransform.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);
                tdes.Clear();
                return Convert.ToBase64String(passwordArray, 0, passwordArray.Length);
            }

            /// <summary>
            /// Decrypts a ciphered connection string. This is done for you while reading the configs.
            /// </summary>
            /// <param name="cipheredConnectionString">encrypted:0jx0NNG6POnEZ4/5VKXfeUj0u5WhEa9AEdPx7mYrIiFGmPNPJw8dVZvrcc8gjuy35mz/lt8M2s4e9dQFXHZzgQ##</param>
            /// <returns>Server=localhost;User=myusername;Password=mypassword;Charser=NONE;Database=C:\Database.fdb</returns>
            public static string DecryptConnectionString(string cipheredConnectionString)
            {
                cipheredConnectionString = cipheredConnectionString.Replace("encrypted:", String.Empty);

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] tdesKey = encoding.GetBytes(encryptionkey.Substring(0, 24));
                byte[] passwordBytes = Convert.FromBase64String(cipheredConnectionString);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = tdesKey;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] passwordArray = cTransform.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(passwordArray);
            }

        }
    }
}

/*

Config 1. Connection settings in app.config, web.config or settings.settings:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <connectionStrings>
            <add name="database1" connectionString="Server=localhost;Integrated Security=SSPI;Database=Northwind;" providerName="System.Data.SqlClient" />
            <add name="database2" connectionString="Data Source=|DataDirectory|\Database.sdf" providerName="System.Data.SqlServerCe.3.5" />
            <add name="database3" connectionString="Data Source=|DataDirectory|\Database.sqlite;Version=3;" providerName="System.Data.SQLite" />
            <add name="database4" connectionString="server=localhost;user id=myusername;password=mypassword;persist security info=True;database=mydatabasename;CharSet='utf8';" providerName="MySql.Data.MySqlClient" />
            <add name="database5" connectionString="SERVER=localhost;Database=mydatabasename;User name=myusername;Password=mypassword" providerName="Npgsql2" />
            <add name="database6" connectionString="Server=localhost;User=myusername;Password=mypassword;Charser=NONE;Database=C:\Database.fdb" providerName="FirebirdSql.Data.FirebirdClient" />
            <add name="database7" connectionString="encrypted:0jx0NNG6POnEZ4/5VKXfeUj0u5WhEa9AEdPx7mYrIiFGmPNPJw8dVZvrcc8gjuy35mz/lt8M2s4e9dQFXHZzgQ##" providerName="System.Data.SqlClient" />
        </connectionStrings>
    </configuration>


Config 2. Connection settings in any xml store, like databases.xml:

    <?xml version="1.0" encoding="utf-8"?>
    <databases>
      <database>
        <name>database8</name>
        <connectionString>Server=localhost;Integrated Security=SSPI;Database=Northwind;</connectionString>
        <providerName>System.Data.SqlClient</providerName>
      </database>
    </databases>




Example 1. Create connection object and retrieve version info.

    using Databases;
    using (var database1 = Database.Connection("database1"))
    {
        string version = database1.ServerVersion;
    }


Example 2. Create a connection and open it immediately for queries. Run a couple of queries, maybe with Dapper (nuget dapper, http://code.google.com/p/dapper-dot-net/).

    using Databases;
    using Dapper;
    using (var database2 = Database.Open("database2"))
    {
        List<Dog> dogs = database1.Query<Dog>("SELECT * FROM dogs").ToList();
        Console.WriteLine("Total dogs found: " + dogs.Count());

        Dog dog = database1.Query<Dog>("SELECT * FROM dogs WHERE name = @Name", new { Name = "Pluto" }).First();
        Console.WriteLine("Pluto is years old: " + dog.Age);
    }


Example 3. Opening a connection from encrypted connection string is done for you:

    DbConnection database1 = Database.Open("database1");
    // do something ...
    database1.Close();


Example 4. Writing a tool to encrypt connection strings for new configurations is easy:

    using Databases;
    Console.WriteLine("Enter the connection string to encrypt and press enter: ");
    string connectionString = Console.ReadLine();
    string encryped = Database.Sources.EncryptConnectionString(connectionString);
    Console.WriteLine("Put in web.config: " + encryped);

*/
