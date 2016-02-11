namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IArticleCategoryService
    {
        IQueryable<AtricleCategory> All();
    }
}
