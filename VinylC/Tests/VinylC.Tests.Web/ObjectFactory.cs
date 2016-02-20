namespace VinylC.Tests.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using Data.Models;
    using Moq;
    using Services.Data.Contracts;

    public static class ObjectFactory
    {
        public static IQueryable<AtricleCategory> articlesCategories = new List<AtricleCategory>
        {
            new AtricleCategory() { Id = 1, Name = "Music" },
            new AtricleCategory() { Id = 2, Name = "History" }
        }.AsQueryable();

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
                    Id = 1,
                    Title = "New iPhone 7",
                    Description = "According to Apple's traditional cadence, new iPhone models debut in the fall.",
                    Price = 999,
                    ReleaseDate = new DateTime(2016,9,25),
                    User = new User
                    {
                        UserName = "123456",
                        Avatar = Avatar.DefaultAvatar
                    },
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
                    Id = 2,
                    Title = "Audio-Technica Wireless",
                    Description = "Bluetooth-compatible + fully automatic belt-driven turntable from Audio-Technica.",
                    Price = 180,
                    ReleaseDate = new DateTime(2016,4,21),
                    User = new User
                    {
                        UserName = "123456",
                        Avatar = Avatar.DefaultAvatar
                    },
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

            productService.Setup(x => x.ProductById(
                It.Is<int>(v => v == 1)))
                .Returns(products.Where(x => x.Id == 1));

            productService.Setup(x => x.AddRating(
                    It.Is<int>(v => v == 1),
                    It.Is<int>(r => r > 0 && r < 6),
                    It.IsAny<string>()
                ))
                .Returns(3.5f);

            return productService.Object;
        }

        public static IArticleService GetArticleService()
        {
            var articlesService = new Mock<IArticleService>();

            articlesService.Setup(x => x.AddArticle(
                It.IsAny<Article>()))
                .Returns(new Article { Id = 5 });

            articlesService.Setup(x => x.AllArticles())
                .Returns(articles);

            articlesService.Setup(x => x.ArticleById(
                It.Is<int>(v => v == 1)))
                .Returns(articles.Where(x => x.Id == 1));

            articlesService.Setup(x => x.AllByCategory(
                It.IsAny<string>()))
                .Returns(articles);

            return articlesService.Object;
        }

        public static IAtricleCategoriesService GetAtricleCategoriesService()
        {
            var articlesCategoriesService = new Mock<IAtricleCategoriesService>();

            articlesCategoriesService.Setup(x => x.AllArticleCategories())
               .Returns(articlesCategories);

            return articlesCategoriesService.Object;
        }

        public static IUserService GetUserService()
        {
            var userService = new Mock<IUserService>();

            userService.Setup(x => x.GetUser(
                It.IsAny<string>()))
                .Returns(new User
                {
                    Id = "123456",
                    UserName = "TestUser"
                });

            return userService.Object;
        }
    }
}
