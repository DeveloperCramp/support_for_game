using Microsoft.EntityFrameworkCore;
using System;
using WebApp.Models;

namespace Db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=MeGamePass15;database=megame_support;", 
                new MySqlServerVersion(new Version(8, 0, 29))
                );
        }

    }
}
