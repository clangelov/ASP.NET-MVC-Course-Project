namespace VinylC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Place
    {
        private ICollection<Tag> tags;
        private ICollection<Opinion> opinions;

        public Place()
        {
            this.tags = new HashSet<Tag>();
            this.opinions = new HashSet<Opinion>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.TitleMinLength)]
        [MaxLength(ModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual GeoLocation GeoLocation { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Opinion> Opinions
        {
            get { return this.opinions; }
            set { this.opinions = value; }
        }
    }
}
