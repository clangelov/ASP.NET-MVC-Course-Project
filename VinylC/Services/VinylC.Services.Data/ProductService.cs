namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> products;

        public ProductService(IRepository<Product> products)
        {
            this.products = products;
        }

        public Product AddArticle(Product toAdd)
        {
            this.products.Add(toAdd);
            this.products.SaveChanges();

            return toAdd;
        }

        public IQueryable<Product> AllProducts()
        {
            return this.products.All().OrderBy(x => x.ReleaseDate);
        }

        public IQueryable<Product> ProductById(int id)
        {
            return this.products.All().Where(x => x.Id == id);
        }
    }
}
