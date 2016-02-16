namespace VinylC.Web.MVC.Areas.Administration.Models.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Validation;
    using VinylC.Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ProductAdminViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

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

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [CustomDateRange]
        public DateTime ReleaseDate { get; set; }

        public string UserId { get; set; }
    }
}