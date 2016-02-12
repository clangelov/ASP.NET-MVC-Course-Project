namespace VinylC.Web.MVC.Areas.Private.Models.Articles
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class AddCommentViewModel : IMapFrom<Comment>
    {
        public AddCommentViewModel()
        {
        }

        public AddCommentViewModel(int articleId)
        {
            this.ArticleId = articleId;
        }

        [Required]
        [UIHint("MultiLineText")]
        [MaxLength(ModelConstants.CommentLenght)]
        public string Replay { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public string UserId { get; set; }

        public int ArticleId { get; set; }
    }
}