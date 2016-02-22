namespace VinylC.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using VinylC.Data.Models;

    public class VinylCDbContext : IdentityDbContext<User>, IVinylCDbContext
    {
        public VinylCDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<AtricleCategory> AtricleCategories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<GeoLocation> GeoLocations { get; set; }

        public virtual IDbSet<Place> Places { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public virtual IDbSet<Opinion> Opinions { get; set; }

        public static VinylCDbContext Create()
        {
            return new VinylCDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Article>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Article)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Message>()
                .HasOptional(c => c.ToUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Message>()
                .HasOptional(c => c.FromUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
