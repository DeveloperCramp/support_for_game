using Db.Models;
using System;
using System.Threading.Tasks;

namespace Db
{
    public interface IAdminsDbStorage
    {
        Task AddAsync(Admin admin);
        Task<Admin> TryGetByIdAsync(Guid id);
        Task<Admin> TryGetByMailAsync(string mail);
    }
}