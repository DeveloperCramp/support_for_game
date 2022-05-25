using System;

namespace Db.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Player Player { get; set; }
        public Admin Admin { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }

        public Message()
        {
            CreateDateTime = DateTime.Now;
        }
    }
}
