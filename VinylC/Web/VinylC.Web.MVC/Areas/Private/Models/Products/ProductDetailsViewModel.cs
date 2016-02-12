using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VinylC.Data.Models;
using VinylC.Web.MVC.Infrastructure.Mappings;

namespace VinylC.Web.MVC.Areas.Private.Models.Products
{
    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public float Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
               .ForMember(e => e.Rating, opts => opts.MapFrom(e => e.Ratings.Any() ? e.Ratings.Average(r => r.Value) : 0.0f));
        }
    }
}