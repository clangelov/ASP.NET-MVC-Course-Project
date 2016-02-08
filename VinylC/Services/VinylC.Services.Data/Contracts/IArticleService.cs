namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IArticleService
    {
        IQueryable<Article> AllArticles();

        Article ArticleById(int id);
    }
}
