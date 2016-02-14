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
            throw new NotImplementedException();
        }

        public IQueryable<Message> AllToUserId(string id)
        {
            return this.messages.All().Where(m => m.FromUserId == id);
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
