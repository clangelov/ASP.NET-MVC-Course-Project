namespace VinylC.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using VinylC.Common.Constants;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(ModelConstants.MinRating, ModelConstants.MaxRating)]
        public int Value { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UserId { get; set; }

        public virtual User Users { get; set; }
    }
}
