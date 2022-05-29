using System.Data.Entity.Migrations;
using It2g.Core.Dao.Migration;
using It2g.Reporter.Dao;

namespace It2g.Reporter.Migrations
{
    /// <summary>
    /// Конфигурация миграции Code-First
    /// 
    /// Заполнение базы данных тестовыми значениями.
    /// Просьба ко всем добавляющим тестовые данные по каждой сущности, вставлять их в скобки #region
    /// для упорядочивания  и добавлением метода context.SaveChanges(); после заполнения данных, чтобы можно
    /// было проще отслеживать ошибки заполнения.
    /// </summary>
    public sealed class Configuration : DbMigrationsConfiguration<ReporterDbContext>
    {
        public Configuration()
        {
            this.ConfigureMigrationsHistory(new[]
            {
                "Npgsql",
                "System.Data.SqlClient"
            }, "general");

            SetSqlGenerator("Npgsql", new PatchedNpgsqlMigrationSqlGenerator());
        }

        protected override void Seed(ReporterDbContext context)
        {
            base.Seed(context);


        }
    }
}

