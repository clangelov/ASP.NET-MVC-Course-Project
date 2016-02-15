namespace VinylC.Services.Data.Contracts
{
    using System.Linq;
    using VinylC.Data.Models;

    public interface IMessageService
    {
        IQueryable<Message> AllToUserId(string id);

        IQueryable<Message> AllFromUserId(string id);

        Message AddMessage(Message toAdd);

        void MarkAsRead(int id);
    }
}
