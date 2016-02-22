namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class TagService : ITagService
    {
        private readonly IRepository<Tag> tags;

        public TagService(IRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<Tag> MostPopular(int count)
        {
            return this.tags.All().OrderByDescending(t => t.Places.Count).Take(count);
        }
    }
}
