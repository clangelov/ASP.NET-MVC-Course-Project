namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly IRepository<AtricleCategory> articleCategories;

        public ArticleCategoryService(IRepository<AtricleCategory> articleCategories)
        {
            this.articleCategories = articleCategories;
        }

        public IQueryable<AtricleCategory> All()
        {
            return this.articleCategories.All();
        }

        public AtricleCategory CreateNewCategory(AtricleCategory categoryToAdd)
        {
            this.articleCategories.Add(categoryToAdd);
            this.articleCategories.SaveChanges();

            return categoryToAdd;
        }

        public AtricleCategory UpdateCategory(AtricleCategory updated)
        {
            this.articleCategories.Update(updated);
            this.articleCategories.SaveChanges();

            return updated;
        }
    }
}
