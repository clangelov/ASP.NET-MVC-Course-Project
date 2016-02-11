namespace VinylC.Services.Data.Contracts
{
    using VinylC.Data.Models;

    public interface IUserService
    {
        User GetUser(string name);
    }
}
