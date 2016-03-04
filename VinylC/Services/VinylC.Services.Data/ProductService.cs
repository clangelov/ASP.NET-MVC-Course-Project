namespace VinylC.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> products;

        private readonly IRepository<Rating> ratings;

        public ProductService(IRepository<Product> products, IRepository<Rating> ratings)
        {
            this.products = products;
            this.ratings = ratings;
        }

        public async Task<Product> AddProduct(Product toAdd)
        {
            this.products.Add(toAdd);
            await this.products.SaveChangesAsync();

            return toAdd;
        }

        public float AddRating(int productId, int rating, string userID)
        {
            
            if (this.ratings.All().Any(r => r.UserId == userID && r.ProductId == productId))
            {
                var myCurrentRating = this.ratings.All().Where(r => r.UserId == userID && r.ProductId == productId).FirstOrDefault();
                myCurrentRating.Value = rating;
                this.ratings.Update(myCurrentRating);
                this.ratings.SaveChanges();

                return (float)this.products.All().Where(p => p.Id == productId).Select(e => e.Ratings.Average(r => r.Value)).First();
            }
            
            var ratingToAdd = new Rating
            {
                ProductId = productId,
                Value = rating,
                UserId = userID
            };

            this.ratings.Add(ratingToAdd);
            this.ratings.SaveChanges();

            return (float)this.products.All().Where(p => p.Id == productId).Select(e => e.Ratings.Average(r => r.Value)).First();
        }

        public IQueryable<Product> AllProducts()
        {
            return this.products.All().OrderBy(x => x.ReleaseDate);
        }

        public void DeleteProduct(int id)
        {
            this.products.Delete(id);
            this.products.SaveChanges();
        }

        public IQueryable<Product> GetHighestRated(int count)
        {
            return this.products.All()
                .OrderByDescending(p => p.Ratings.Any() ? p.Ratings.Average(r => r.Value) : 0)
                .ThenBy(p => p.ReleaseDate)
                .Take(count);
        }

        public IQueryable<Product> ProductById(int id)
        {
            return this.products.All().Where(x => x.Id == id);
        }

        public IQueryable<Product> UpdateProduct(Product update)
        {
            this.products.Update(update);
            this.products.SaveChanges();

            return this.products.All().Where(x => x.Id == update.Id);
        }
    }
}
