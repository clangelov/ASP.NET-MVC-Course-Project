namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> articles;

        public ArticleService(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> AllArticles()
        {
            return this.articles.All().OrderByDescending(x => x.PostedOn);
        }

        public Article ArticleById(int id)
        {
            return this.articles.GetById(id);
        }
    }
}
