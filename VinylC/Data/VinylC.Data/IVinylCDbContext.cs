﻿namespace VinylC.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IVinylCDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Article> Articles { get; set; }

        IDbSet<AtricleCategory> AtricleCategories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}