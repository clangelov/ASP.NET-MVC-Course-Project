namespace VinylC.Web.MVC.Areas.Private.Models.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using Infrastructure.Validation;
    using VinylC.Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ProductSaveViewModel : IMapFrom<Product>
    {
        [Required]
        [MinLength(ModelConstants.TitleMinLength)]
        [MaxLength(ModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [UIHint("MultiLineText")]
        [MinLength(ModelConstants.ContentMinLength)]
        [MaxLength(ModelConstants.ContentMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(0, ModelConstants.ProductMaxValue)]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        [NotMapped]
        [ValidateFile(ErrorMessage = "Please select a JPEG image smaller than 1MB")]
        public HttpPostedFileBase File { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [CustomDateRange]
        public DateTime ReleaseDate { get; set; }

        public string UserId { get; set; }
    }
}