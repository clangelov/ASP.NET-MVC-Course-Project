namespace VinylC.Web.MVC.Areas.Administration.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using VinylC.Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class UserAdminViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [RegularExpression(ModelConstants.ValidateUrl)]
        public string Avatar { get; set; }
    }
}