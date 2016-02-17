namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IUserService
    {
        User GetUser(string name);

        IQueryable<User> UserById(string id);

        IQueryable<User> All();

        User UpdateUser(User userToUpdate, string role);

        void DeleteUser(string id);
    }
}
