namespace VinylC.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Article
    {
        private ICollection<Comment> comments;

        public Article()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Contetnt { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int AtricleCategoryId { get; set; }

        public virtual AtricleCategory AtricleCategory { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
