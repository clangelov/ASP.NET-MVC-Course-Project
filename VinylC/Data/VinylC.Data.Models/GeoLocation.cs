namespace VinylC.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GeoLocation
    {
        [Key, ForeignKey("Place")]
        public int PlaceId { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        public virtual Place Place { get; set; }
    }
}
