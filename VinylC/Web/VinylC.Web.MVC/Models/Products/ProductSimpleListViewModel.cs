namespace VinylC.Web.MVC.Models.Products
{
    using System.Linq;
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ProductSimpleListViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductSimpleListViewModel>()
               .ForMember(e => e.Rating, opts => opts.MapFrom(e => e.Ratings.Any() ? e.Ratings.Average(r => r.Value) : 0.0f));
        }
    }
}