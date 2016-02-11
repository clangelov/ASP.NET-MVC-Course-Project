namespace VinylC.Web.MVC.Areas.Private.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    using Data.Models;
    using VinylC.Common.Constants;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ArticlesSaveViewModel : IMapFrom<Article>
    {
        [Required]
        [MinLength(ModelConstants.ArticleTitleMinLength)]
        [MaxLength(ModelConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        [MinLength(ModelConstants.ArticleMinLength)]
        [MaxLength(ModelConstants.ArticleMaxLength)]
        public string Contetnt { get; set; }

        public string UserId { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Display(Name = "Article Category")]
        public int AtricleCategoryId { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> AtricleCategory { get; set; }
    }
}