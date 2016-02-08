namespace VinylC.Web.MVC
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VinylCDbContext, Configuration>());
            VinylCDbContext.Create().Database.Initialize(true);
        }
    }
}