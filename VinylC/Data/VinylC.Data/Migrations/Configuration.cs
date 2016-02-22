namespace VinylC.Data.Migrations
{
    using System.Data.Entity.Migrations;
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
            new ArticlesSeeder().Seed(context);
            new ProductSeeder().Seed(context);
            new PlacesSeeder().Seed(context);
        }
    }
}
