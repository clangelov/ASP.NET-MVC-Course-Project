namespace VinylC.Web.MVC.Areas.Administration.Models.Category
{
    using System.ComponentModel.DataAnnotations;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class CategoryAdminViewModel : IMapFrom<AtricleCategory>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}