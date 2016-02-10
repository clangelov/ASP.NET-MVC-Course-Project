namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface ICommentService
    {
        Comment AddNew(Comment toAdd);

        IQueryable<Comment> AllByArticel(int id);
    }
}
