namespace VinylC.Web.MVC.Models.Comments
{
    using System;
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class CommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Replay { get; set; }

        public DateTime PostedOn { get; set; }

        public string Avatar { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsViewModel>()
               .ForMember(r => r.Avatar, opts => opts.MapFrom(x => x.User.Avatar))
               .ForMember(r => r.UserName, opts => opts.MapFrom(x => x.User.UserName))
               .ReverseMap(); 
        }
    }
}