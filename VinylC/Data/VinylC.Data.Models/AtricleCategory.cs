namespace VinylC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AtricleCategory
    {
        private ICollection<Article> atricles;

        public AtricleCategory()
        {
            this.atricles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.atricles; }
            set { this.atricles = value; }
        }
    }
}
