namespace VinylC.Web.MVC.Areas.Administration.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using VinylC.Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class UserAdminViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [RegularExpression(ModelConstants.ValidateUrl)]
        public string Avatar { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserAdminViewModel>()
               .ForMember(m => m.Role, opt => opt.MapFrom(x => x.Roles.Count == 1 ? "Admin" : "User"));
        }
    }
}