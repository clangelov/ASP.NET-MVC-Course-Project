namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IArticleCategoryService
    {
        IQueryable<AtricleCategory> All();

        AtricleCategory CreateNewCategory(AtricleCategory categoryToAdd);

        AtricleCategory UpdateCategory(AtricleCategory updated);
    }
}
