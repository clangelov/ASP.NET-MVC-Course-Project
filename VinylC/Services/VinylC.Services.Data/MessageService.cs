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
            this.messages.Add(toAdd);
            this.messages.SaveChanges();

            return toAdd;
        }

        public IQueryable<Message> AllFromUserId(string id)
        {
            return this.messages.All().Where(m => m.FromUserId == id);
        }

        public IQueryable<Message> AllToUserId(string id)
        {
            return this.messages.All().Where(m => m.ToUserId == id && m.IsRead == false);
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
