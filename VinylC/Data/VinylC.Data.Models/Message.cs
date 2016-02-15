namespace VinylC.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.MessageMaxLenght)]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime Posted { get; set; }

        [ForeignKey("FromUser")]
        public string FromUserId { get; set; }

        public virtual User FromUser { get; set; }

        [ForeignKey("ToUser")]
        public string ToUserId { get; set; }

        public virtual User ToUser { get; set; }      
    }
}
