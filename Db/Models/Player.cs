using System;

namespace Db.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Token { get; set; }
    }
}
