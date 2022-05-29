namespace Kis.Base.Dao.Migration
{
    /// <summary>
    /// Данный пропатченный генератор SQL для PostgreSQL выполняет усечение имён индексов и 
    /// ограничений внешних ключей, т.к. длина имен ограничена 63 символами, и 
    /// обрезается базой данных, при привышении этой длины. При этом, если названия оказываются
    /// не различаются в первых 63 знаках, по возникают ошибки совпадения названий при 
    /// выполнении миграций, хотя названия фактически не совпадают.
    /// Этот генератор предотвращает эту проблему путём усечения имён с добавлением в них хеша от имени,
    /// исключая повторение имён в схеме бд.
    /// </summary>
    //public class PatchedNpgsqlMigrationSqlGenerator : NpgsqlMigrationSqlGenerator
    //{
    //    private const int NameMaxLength = 63;
    //    private const int HashLength = 8;

    //    public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
    //    {
    //        var operations = migrationOperations as MigrationOperation[] ?? migrationOperations.ToArray();
    //        foreach (var operation in operations.OfType<ForeignKeyOperation>())
    //        {
    //            operation.Name = MakeTruncatedName(operation.Name);
    //        }
    //        foreach (var operation in operations.OfType<IndexOperation>())
    //        {
    //            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(operation.Name)).Take(6).ToArray();
    //            var stringHash = string.Join("", hash.Select(o => o.ToString("X2")));
    //            operation.Name = stringHash;
    //        }
    //        return base.Generate(operations, providerManifestToken);
    //    }

    //    private string MakeTruncatedName(string name)
    //    {
    //        if (name.Length < 64)
    //            return name;

    //        var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(name)).Take(HashLength).ToArray();
    //        var stringHash = string.Join("", hash.Select(o => o.ToString("X2")));
    //        return name.Substring(0, NameMaxLength - HashLength*2 - 3) + "___" + stringHash;
    //    }
    //}
}
