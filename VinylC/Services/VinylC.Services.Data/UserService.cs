namespace VinylC.Services.Data
{
    using System;
    using System.Linq;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using VinylC.Data;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;
        private readonly IVinylCDbContext dbContext;

        public UserService(IRepository<User> users, IVinylCDbContext dbContext)
        {
            this.users = users;
            this.dbContext = dbContext;
        }

        public void DeleteUser(string id)
        {
            this.users.Delete(id);
            this.users.SaveChanges();
        }

        public User GetUser(string name)
        {
            var userAsObject = this.users
               .All()
               .Where(x => x.UserName == name)
               .FirstOrDefault();

            return userAsObject;
        }

        public User UpdateUser(User userToUpdate, string role)
        {
            this.users.Update(userToUpdate);

            if (role == Roles.AdminRole)
            {
                var userManager = new UserManager<User>(new UserStore<User>((VinylCDbContext)this.dbContext));
                userManager.AddToRole(userToUpdate.Id, Roles.AdminRole);
            }
            
            this.users.SaveChanges();

            return userToUpdate;
        }

        public IQueryable<User> UserById(string id)
        {
            return this.users.All().Where(x => x.Id == id);
        }

        public IQueryable<User> All()
        {
            return this.users.All();
        }
    }
}
