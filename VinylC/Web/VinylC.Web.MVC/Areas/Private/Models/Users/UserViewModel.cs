namespace VinylC.Web.MVC.Areas.Private.Models.Users
{
    using System.ComponentModel;
    using System.Linq;
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string Avatar { get; set; }

        [DisplayName("Posted Articles")]
        public int AriclesPosted { get; set; }

        [DisplayName("Comments Made")]
        public int CommentsMade { get; set; }

        [DisplayName("Products Added")]
        public int ProductsAdded { get; set; }

        [DisplayName("Products Rated")]
        public int ProductsRated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
               .ForMember(u => u.AriclesPosted, opts => opts.MapFrom(u => u.Articles.Any() ? u.Articles.Count() : 0))
               .ForMember(u => u.CommentsMade, opts => opts.MapFrom(u => u.Comments.Any() ? u.Comments.Count() : 0))
               .ForMember(u => u.ProductsRated, opts => opts.MapFrom(u => u.Products.Any() ? u.Products.Count() : 0))
               .ForMember(u => u.ProductsRated, opts => opts.MapFrom(u => u.Ratings.Any() ? u.Ratings.Count() : 0));
        }
    }
}