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
        [MinLength(ModelConstants.ArticleTitleMinLength)]
        [MaxLength(ModelConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.ArticleMinLength)]
        [MaxLength(ModelConstants.ArticleMaxLength)]
        public string Contetnt { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int AtricleCategoryId { get; set; }

        public virtual AtricleCategory AtricleCategory { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
