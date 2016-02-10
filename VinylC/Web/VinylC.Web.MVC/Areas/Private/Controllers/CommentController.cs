namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MVC.Models.Comments;
    using VinylC.Data.Models;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Private.Models;

    public class CommentController : Controller
    {
        private ICommentService commentsService;
        private IUserService userService;

        public CommentController(IUserService userService, ICommentService commentsService)
        {
            this.commentsService = commentsService;
            this.userService = userService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.userService.GetUserId(this.User.Identity.Name);

                comment = this.commentsService.AddNew(comment);

                // TODO fix View Model
                // TODO fix HTML its ugly
                var viewModel = Mapper.Map<CommentsViewModel>(comment);

                return this.PartialView("~/Areas/Private/Views/Comment/_SingleCommentPartial.cshtml", viewModel);
            }

            throw new HttpException(400, "Invalid Comment");
        }

        public ActionResult GetPageCommentsPartial(int articleId)
        {
            var comments = this.commentsService
                .AllByArticel(articleId)
                .ProjectTo<CommentsViewModel>();

            return this.PartialView("_ArticleCommentsPartial", comments);
        }
    }
}