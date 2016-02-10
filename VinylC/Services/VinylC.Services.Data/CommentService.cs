namespace VinylC.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment AddNew(Comment toAdd)
        {
            toAdd.PostedOn = DateTime.UtcNow;

            this.comments.Add(toAdd);
            this.comments.SaveChanges();

            return toAdd;
        }

        public IQueryable<Comment> AllByArticel(int id)
        {
            return this.comments.All()
                .Where(c => c.ArticleId == id)
                .OrderByDescending(c => c.PostedOn);
        }
    }
}
