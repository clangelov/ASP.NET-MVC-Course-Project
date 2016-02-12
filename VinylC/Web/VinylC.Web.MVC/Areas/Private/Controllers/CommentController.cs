namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Base;
    using MVC.Models.Comments;
    using VinylC.Data.Models;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Private.Models.Articles;

    public class CommentController : BaseController
    {
        private ICommentService commentsService;

        public CommentController(IUserService userService, ICommentService commentsService)
            :base(userService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.CurrentUser.Id;

                comment = this.commentsService.AddNew(comment);

                var viewModel = Mapper.Map<CommentsViewModel>(comment);
                viewModel.Avatar = this.CurrentUser.Avatar;
                viewModel.UserName = this.CurrentUser.UserName;

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