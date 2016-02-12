namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IProductService
    {
        IQueryable<Product> AllProducts();
        
        IQueryable<Product> ProductById(int id);

        Product AddArticle(Product toAdd);
    }
}
