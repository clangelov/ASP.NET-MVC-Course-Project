namespace VinylC.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.CommentLenght)]
        public string Replay { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}