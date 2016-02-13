namespace VinylC.Web.MVC.Areas.Private.Models.Products
{
    using System;
    using System.Linq;
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserAvatar { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
               .ForMember(e => e.Rating, opts => opts.MapFrom(e => e.Ratings.Any() ? e.Ratings.Average(r => r.Value) : 0.0f))
               .ForMember(e => e.UserName, opts => opts.MapFrom(e => e.User.UserName))
               .ForMember(e => e.UserAvatar, opts => opts.MapFrom(e => e.User.Avatar));
        }
    }
}