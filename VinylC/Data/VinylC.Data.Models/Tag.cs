namespace VinylC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        private ICollection<Place> places;

        public Tag()
        {
            this.places = new HashSet<Place>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Place> Places
        {
            get { return this.places; }
            set { this.places = value; }
        }
    }
}
