namespace VinylC.Data.DataSeed
{
    public interface IDataSeeder
    {
        void Seed(VinylCDbContext context);
    }
}
