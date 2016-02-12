namespace VinylC.Web.MVC.Areas.Private.Models.Articles
{
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ArticlesCategoriesViewModel : IMapFrom<AtricleCategory>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AtricleCategory, ArticlesCategoriesViewModel>()
                .ForMember(m => m.Count, opt => opt.MapFrom(x => x.Articles.Count));
        }
    }
}