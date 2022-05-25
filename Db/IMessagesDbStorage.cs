using Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Db
{
    public interface IMessagesDbStorage
    {
        Task AddAsync(Message message);
        Task<List<Message>> GetAllAsync();
        Task<Message> TryGetByIdAsync(Guid id);
        Task UpdateStatus(Guid id, bool isRead);
    }
}