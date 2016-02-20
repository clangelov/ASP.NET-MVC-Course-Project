namespace VinylC.Tests.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Moq;
    using Services.Data.Contracts;

    public static class ObjectFactory
    {
        public static IQueryable<Article> articles = new List<Article>
        {
            new Article() {
                Id = 1,
                Contetnt = "There are few artists in hip-hop who have ever truly matched their hype.",
                ImageUrl = "http://ebid.s3.amazonaws.com/upload_big/1/2/3/1405024178-12177-9126.jpg",
                User = new User
                {
                    UserName = "123456"
                },
                Title = "Nas, 'Illmatic' At 20",
                AtricleCategory = new AtricleCategory
                {
                    Name = "Test"
                },
                PostedOn = new DateTime(2016,9,25)
            },
                new Article() {
                Id = 2,
                Contetnt = "Kendrick Lamar has an Andre 3000 like quality to his delivery.",
                ImageUrl = "https://thisindustrythingofours.files.wordpress.com/2012/10/20121023-131008.jpg",
                User = new User
                {
                    UserName = "123456"
                },
                Title = "Kendrick Lamar smashing new Album",
                AtricleCategory = new AtricleCategory
                {
                    Name = "Test"
                },
                PostedOn = new DateTime(2015,9,25)
            }
        }.AsQueryable();

        public static IQueryable<Product> products = new List<Product>
        {
            new Product
                {
                    Title = "New iPhone 7",
                    Description = "According to Apple's traditional cadence, new iPhone models debut in the fall.",
                    Price = 999,
                    ReleaseDate = new DateTime(2016,9,25),
                    UserId = "123456789",
                    Picture = "/Content/Products/iphone-7.png",
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Value = 5
                        }
                    }
                },
                new Product
                {
                    Title = "Audio-Technica Wireless",
                    Description = "Bluetooth-compatible + fully automatic belt-driven turntable from Audio-Technica.",
                    Price = 180,
                    ReleaseDate = new DateTime(2016,4,21),
                    UserId = "123456789",
                    Picture = "/Content/Products/37762911.jpg",
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Value = 3
                        }
                    }
                }
        }.AsQueryable();

        public static IProductService GetProductService()
        {
            var productService = new Mock<IProductService>();
            productService.Setup(x => x.AllProducts())
                .Returns(products);
            return productService.Object;
        }

        public static IArticleService  GetArticleService()
        {
            var articlesService = new Mock<IArticleService>();
            articlesService.Setup(x => x.AllArticles())
                .Returns(articles);
            return articlesService.Object;
        }

        public static IAtricleCategoriesService GetAtricleCategoriesService()
        {
            var articlesCategoriesService = new Mock<IAtricleCategoriesService>();

            return articlesCategoriesService.Object;
        }
    }
}
