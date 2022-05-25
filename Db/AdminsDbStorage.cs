using Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Db
{
    public class AdminsDbStorage : IAdminsDbStorage
    {
        private readonly DatabaseContext databaseContext;

        public AdminsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Admin> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Admins.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Admin> TryGetByMailAsync(string mail)
        {
            return await databaseContext.Admins.FirstOrDefaultAsync(m => m.Mail == mail);
        }

        public async Task AddAsync(Admin admin)
        {
            await databaseContext.Admins.AddAsync(admin);
            await databaseContext.SaveChangesAsync();
        }
    }
}
