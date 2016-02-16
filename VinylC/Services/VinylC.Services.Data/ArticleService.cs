﻿namespace VinylC.Services.Data
{
    using System;
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

        public Article AddArticle(Article toAdd)
        {
            toAdd.PostedOn = DateTime.UtcNow;
            this.articles.Add(toAdd);
            this.articles.SaveChanges();

            return toAdd;
        }

        public IQueryable<Article> AllArticles()
        {
            return this.articles.All()
                .OrderByDescending(x => x.PostedOn);
        }

        public IQueryable<Article> AllByCategory(string category)
        {
            return this.articles.All()
                .Where(a => a.AtricleCategory.Name == category)
                .OrderByDescending(x => x.PostedOn);
        }

        public IQueryable<Article> ArticleById(int id)
        {
            return this.articles.All()
                .Where(x => x.Id == id);
        }

        public IQueryable<Article> MostCommented(int count)
        {
            return this.articles.All()
                .OrderByDescending(a => a.Comments.Count)
                .ThenByDescending(a => a.PostedOn)
                .Take(count);
        }
    }
}
