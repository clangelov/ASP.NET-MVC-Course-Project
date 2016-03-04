namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using VinylC.Data.Models;

    public interface ICommentService
    {
        Task<Comment> AddNew(Comment toAdd);

        IQueryable<Comment> AllByArticel(int id);

        void DeleteCommentById(int id);
    }
}
