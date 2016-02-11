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
        [Authorize]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                // TODO: extract it in a basic Controller
                var currentUser = this.userService.GetUser(this.User.Identity.Name);
                comment.UserId = currentUser.Id;

                comment = this.commentsService.AddNew(comment);

                var viewModel = Mapper.Map<CommentsViewModel>(comment);
                viewModel.Avatar = currentUser.Avatar;
                viewModel.UserName = currentUser.UserName;

                return this.PartialView("~/Areas/Private/Views/Comment/_SingleCommentPartial.cshtml", viewModel);
            }

            throw new HttpException(400, "Invalid Comment");
        }

        [Authorize]
        public ActionResult Delete(int id, int articleID)
        {
            this.commentsService.DeleteCommentById(id);

            return this.GetPageCommentsPartial(articleID);
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