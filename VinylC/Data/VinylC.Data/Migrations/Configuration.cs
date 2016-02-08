namespace VinylC.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataSeed;

    public sealed class Configuration : DbMigrationsConfiguration<VinylCDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VinylCDbContext context)
        {
            new AdminSeeder().Seed(context);
        }
    }
}
