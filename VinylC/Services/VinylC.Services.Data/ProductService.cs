namespace VinylC.Services.Data
{
    using System;
    using System.Linq;
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

        public Product AddProduct(Product toAdd)
        {
            this.products.Add(toAdd);
            this.products.SaveChanges();

            return toAdd;
        }

        public float AddRating(int productId, int rating, string userID)
        {
            if (this.ratings.All().Where(r => r.UserId == userID && r.ProductId == productId).Any())
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

        public IQueryable<Product> ProductById(int id)
        {
            return this.products.All().Where(x => x.Id == id);
        }
    }
}
