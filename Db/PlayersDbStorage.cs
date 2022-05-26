using Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Db
{
    public class PlayersDbStorage : IPlayersDbStorage
    {
        private readonly DatabaseContext databaseContext;

        public PlayersDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await databaseContext.Players.ToListAsync();
        }

        public async Task<Player> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> TryGetByNickNameAsync(Player player)
        {
            return await databaseContext.Players.FirstOrDefaultAsync(p => p.Nickname == player.Nickname);
        }

        public async Task AddAsync(Player player)
        {
            await databaseContext.Players.AddAsync(player);
            await databaseContext.SaveChangesAsync();
        }
    }
}
