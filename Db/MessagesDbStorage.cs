using Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Db
{
    public class MessagesDbStorage : IMessagesDbStorage
    {
        private readonly DatabaseContext databaseContext;

        public MessagesDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await databaseContext.Messages.ToListAsync();
        }

        public async Task<Message> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Message message)
        {
            await databaseContext.Messages.AddAsync(message);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateStatus(Guid id, bool isRead)
        {
            var message = await TryGetByIdAsync(id);
            if (isRead == true)
            {
                message.IsRead = true;
                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
