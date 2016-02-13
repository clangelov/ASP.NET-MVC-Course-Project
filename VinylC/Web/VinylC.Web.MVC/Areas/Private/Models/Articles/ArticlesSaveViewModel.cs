namespace VinylC.Web.MVC.Areas.Private.Models.Articles
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
        [MinLength(ModelConstants.TitleMinLength)]
        [MaxLength(ModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        [MinLength(ModelConstants.ContentMinLength)]
        [MaxLength(ModelConstants.ContentMaxLength)]
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