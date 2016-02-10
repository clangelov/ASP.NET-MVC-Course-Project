namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class AtricleCategoriesService : IAtricleCategoriesService
    {
        private readonly IRepository<AtricleCategory> categories;

        public AtricleCategoriesService(IRepository<AtricleCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<AtricleCategory> AllArticleCategories()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
