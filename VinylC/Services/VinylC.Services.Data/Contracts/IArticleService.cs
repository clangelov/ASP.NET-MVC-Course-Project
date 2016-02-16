namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IArticleService
    {
        IQueryable<Article> AllArticles();

        IQueryable<Article> AllByCategory(string category);

        IQueryable<Article> ArticleById(int id);

        IQueryable<Article> MostCommented(int count);

        Article AddArticle(Article toAdd);

        IQueryable<Article> UpdateArticle(Article update);

        void DeleteArticle(int id);
    }
}
