using System;

namespace WebApp.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Player Player { get; set; }
        public Operator Operator { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}
