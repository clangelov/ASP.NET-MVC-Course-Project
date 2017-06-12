namespace VinylC.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using DataSeed;

    public sealed class Configuration : DbMigrationsConfiguration<VinylCDbContext>
    {
        public Configuration()
        {
#if DEBUG
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
#endif
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
