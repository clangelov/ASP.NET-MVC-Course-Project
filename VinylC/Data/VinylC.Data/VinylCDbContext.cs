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

        public static VinylCDbContext Create()
        {
            return new VinylCDbContext();
        }
    }
}
