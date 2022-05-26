using Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Db
{
    public interface IPlayersDbStorage
    {
        Task AddAsync(Player player);
        Task<List<Player>> GetAllAsync();
        Task<Player> TryGetByIdAsync(Guid id);
        Task<Player> TryGetByNickNameAsync(Player player);
    }
}