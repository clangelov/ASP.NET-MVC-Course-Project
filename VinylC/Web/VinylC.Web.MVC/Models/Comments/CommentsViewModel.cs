namespace VinylC.Web.MVC.Models.Comments
{
    using System;
    using AutoMapper;
    using Users;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class CommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Replay { get; set; }

        public DateTime PostedOn { get; set; }

        public SimpleUserViewModel User { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsViewModel>()
               .ForMember(r => r.User, opts => opts.MapFrom(x => x.User));
        }
    }
}