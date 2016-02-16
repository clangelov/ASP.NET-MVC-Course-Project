namespace VinylC.Web.MVC.Areas.Administration.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ArticleAdminViewModel : IMapFrom<Article>
    {
        [Key]
        public int Id { get; set; }

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
    }
}