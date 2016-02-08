namespace VinylC.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using VinylC.Data.Models;

    public class VinylCDbContext : IdentityDbContext<User>, IVinylCDbContext
    {
        public VinylCDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static VinylCDbContext Create()
        {
            return new VinylCDbContext();
        }
    }
}
