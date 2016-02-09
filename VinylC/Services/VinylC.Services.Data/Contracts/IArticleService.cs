namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IArticleService
    {
        IQueryable<Article> AllArticles();

        IQueryable<Article> AllByCategory(string category);

        IQueryable<Article> ArticleById(int id);
    }
}
