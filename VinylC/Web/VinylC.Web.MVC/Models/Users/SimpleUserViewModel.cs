namespace VinylC.Web.MVC.Models.Users
{
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class SimpleUserViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Avatar { get; set; }
    }
}