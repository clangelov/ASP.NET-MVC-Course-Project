namespace VinylC.Web.MVC.Models.Articles
{
    using System.Linq;
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ArticleSimpleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleSimpleViewModel>()
                .ForMember(m => m.CommentsCount, opt => opt.MapFrom(x => x.Comments.Any() ? x.Comments.Count() : 0));
        }
    }
}