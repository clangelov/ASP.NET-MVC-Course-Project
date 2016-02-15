namespace VinylC.Web.MVC.Areas.Private.Models.Messages
{
    using AutoMapper;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class MessageViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
               .ForMember(u => u.From, opts => opts.MapFrom(u => u.FromUser.UserName))
               .ForMember(u => u.To, opts => opts.MapFrom(u => u.ToUser.UserName));
        }
    }
}