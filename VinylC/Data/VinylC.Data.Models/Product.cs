namespace VinylC.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Product
    {
        private ICollection<Rating> ratings;

        public Product()
        {
            this.ratings = new HashSet<Rating>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.TitleMinLength)]
        [MaxLength(ModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.ContentMinLength)]
        [MaxLength(ModelConstants.ContentMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(0, ModelConstants.ProductMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Picture { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }        

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
