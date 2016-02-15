namespace VinylC.Services.Data
{
    using System;
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messages;

        public MessageService(IRepository<Message> messages)
        {
            this.messages = messages;
        }

        public Message AddMessage(Message toAdd)
        {
            toAdd.Posted = DateTime.UtcNow;

            this.messages.Add(toAdd);
            this.messages.SaveChanges();

            return toAdd;
        }

        public IQueryable<Message> AllFromUserId(string id)
        {
            return this.messages.All()
                .Where(m => m.FromUserId == id)
                .OrderByDescending(m => m.Posted);
        }

        public IQueryable<Message> AllToUserId(string id)
        {
            return this.messages.All()
                .Where(m => m.ToUserId == id && m.IsRead == false)
                .OrderByDescending(m => m.Posted);
        }

        public void MarkAsRead(int id)
        {
            var messageToUpdate = this.messages.All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (messageToUpdate != null)
            {
                messageToUpdate.IsRead = true;
                this.messages.Update(messageToUpdate);
                this.messages.SaveChanges();
            }
        }
    }
}
