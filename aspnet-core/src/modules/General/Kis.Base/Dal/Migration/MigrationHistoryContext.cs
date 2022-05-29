namespace Kis.Base.Dao.Migration
{
    /// <summary>
    /// Класс используется, для настройки таблицы миграций EntityFramework, позволяет переопределить
    /// имя таблицы, её схему и имена столбцов. Если они не заданы явно, предлагает принятую для
    /// модулей реализацию по умолчанию.
    /// </summary>
    //public class MigrationHistoryContext<TContext> : HistoryContext
    //    where TContext : DbContext
    //{
    //    public const string DefaultMigrationTableName = "__migrations";
    //    public TContext DbContext { get; set; }

    //    /// <summary>
    //    /// Переопределённое имя схемы для таблицы миграций
    //    /// </summary>
    //    public string SchemaName { get; set; }
    //    /// <summary>
    //    /// Переопределённое имя таблицы миграций
    //    /// </summary>
    //    public string TableName { get; set; }
    //    /// <summary>
    //    /// Переопределённые имена столбцов таблицы миграций
    //    /// </summary>
    //    public MigrationHistoryColumnNames ColumnName { get; set; }

    //    public MigrationHistoryContext(System.Data.Common.DbConnection dbConnection, string defaultSchema)
    //        : base(dbConnection, defaultSchema)
    //    {
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //        if (ColumnName == null) ColumnName = new MigrationHistoryColumnNames();
    //        var historyConfig = modelBuilder.Entity<HistoryRow>();
    //        historyConfig.Property(p => p.ContextKey).HasColumnName(ColumnName.ContextKey ?? MigrationHistoryColumnNames.DefaultContextKeyName);
    //        historyConfig.Property(p => p.MigrationId).HasColumnName(ColumnName.MigrationId ?? MigrationHistoryColumnNames.DefaultMigrationIdName);
    //        historyConfig.Property(p => p.Model).HasColumnName(ColumnName.Model ?? MigrationHistoryColumnNames.DefaultModelName);
    //        historyConfig.Property(p => p.ProductVersion).HasColumnName(ColumnName.ProductVersion ?? MigrationHistoryColumnNames.DefaultProductVersionName);
    //        if (string.IsNullOrWhiteSpace(SchemaName))
    //        {
    //            historyConfig.ToTable(TableName ?? DefaultMigrationTableName);
    //        }
    //        else
    //        {
    //            historyConfig.ToTable(TableName ?? DefaultMigrationTableName, SchemaName);
    //        }
    //    }
    //}

    //public class MigrationHistoryColumnNames
    //{
    //    public const string DefaultContextKeyName = "context_key";
    //    public const string DefaultMigrationIdName = "migration_id";
    //    public const string DefaultModelName = "model";
    //    public const string DefaultProductVersionName = "product_version";

    //    /// <summary>
    //    /// Переопределённое имя столбца ключа контекста данных
    //    /// </summary>
    //    public string ContextKey { get; set; }
    //    /// <summary>
    //    /// Переопределённое имя ключевого столбца с ид миграции
    //    /// </summary>
    //    public string MigrationId { get; set; }
    //    /// <summary>
    //    /// Переопределённое имя столбца с данными о структуре модели
    //    /// </summary>
    //    public string Model { get; set; }
    //    /// <summary>
    //    /// Переопределённое имя столбца с версией EF
    //    /// </summary>
    //    public string ProductVersion { get; set; }
    //}

    //public static class DbMigrationsConfigurationExtensions
    //{
    //    /// <summary>
    //    /// Настраивает конфигурацию мигратора EntityFramework на использование персональной для модуля
    //    /// таблицы миграций. В параметрах можно переопределить имя схемы, таблицы и каждого поля в ней,
    //    /// иначе используются принятые для модулей значения по умолчанию
    //    /// </summary>
    //    /// <param name="configuration">Настраиваемая конфигурация миграций</param>
    //    /// <param name="providerInvariantNames">Список инвариантов провайдеров, для которых
    //    /// устанавливается настройка таблицы миграций</param>
    //    /// <param name="schemaName">Заданное имя схемы таблицы миграций</param>
    //    /// <param name="tableName">Заданное имя таблицы миграций</param>
    //    /// <param name="columnNames">Заданные имена столбцов таблицы миграций</param>
    //    public static void ConfigureMigrationsHistory<TContext>(this DbMigrationsConfiguration<TContext> configuration,
    //        string[] providerInvariantNames, string schemaName = null,
    //        string tableName = null, MigrationHistoryColumnNames columnNames = null)
    //        where TContext : DbContext
    //    {
    //        if (configuration == null)
    //            throw new ArgumentNullException("configuration");

    //        //MigrationHistoryContext<TContext> migrationHistoryContext = null;
    //        Func<System.Data.Common.DbConnection, string, HistoryContext> factory =
    //            (connection, defaultSchema) => new MigrationHistoryContext<TContext>(connection, defaultSchema)
    //                                               {
    //                                                   ColumnName = columnNames,
    //                                                   SchemaName = schemaName,
    //                                                   TableName = tableName
    //                                               };
    //        foreach (var providerInvariantName in providerInvariantNames)
    //        {
    //            configuration.SetHistoryContextFactory(providerInvariantName, factory);
    //        }
    //    }
    //}
}
