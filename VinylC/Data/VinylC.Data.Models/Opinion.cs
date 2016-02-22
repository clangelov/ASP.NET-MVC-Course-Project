namespace VinylC.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using VinylC.Common.Constants;

    public class Opinion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.MinOpinionLenght)]
        [MaxLength(ModelConstants.MessageMaxLenght)]
        public string Content { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
