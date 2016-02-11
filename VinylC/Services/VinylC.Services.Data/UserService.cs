namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }      

        public User GetUser(string name)
        {
            var userAsObject = this.users
               .All()
               .Where(x => x.UserName == name)
               .FirstOrDefault();

            return userAsObject;
        }
    }
}
