namespace VinylC.Web.MVC.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;
    using VinylC.Web.MVC.Models.Comments;

    public class ArticlesDetailsViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Contetnt { get; set; }

        public DateTime PostedOn { get; set; }

        public string User { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public IEnumerable<CommentsViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticlesDetailsViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.AtricleCategory.Name))
                .ForMember(m => m.User, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(m => m.Comments, opt => opt.MapFrom(x => x.Comments));
        }
    }
}