namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface ITagService
    {
        IQueryable<Tag> MostPopular(int count);
    }
}
