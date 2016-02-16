namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IProductService
    {
        IQueryable<Product> AllProducts();
        
        IQueryable<Product> ProductById(int id);

        IQueryable<Product> GetHighestRated(int count);

        Product AddProduct(Product toAdd);

        IQueryable<Product> UpdateProduct(Product update);

        void DeleteProduct(int id);

        float AddRating(int productId, int rating, string userID);
    }
}
