namespace VinylC.Web.MVC.Areas.Private.Models.Messages
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class MessageSaveViewModel : IMapFrom<Message>
    {
        public MessageSaveViewModel()
        {
        }

        public MessageSaveViewModel(string toUserId, string toUserName)
        {
            this.ToUserId = toUserId;
            this.ToUserName = toUserName;
        }

        [Required]
        [UIHint("MultiLineText")]
        [MaxLength(ModelConstants.MessageMaxLenght)]
        public string Content { get; set; }

        public string FromUserId { get; set; }

        public string ToUserId { get; set; }

        [NotMapped]
        public string ToUserName { get; set; }
    }
}