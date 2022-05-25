using System;

namespace Db.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
