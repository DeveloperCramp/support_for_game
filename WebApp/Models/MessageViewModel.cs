using System;

namespace WebApp.Models
{
    public class MessageViewModel
    {
        public PlayerViewModel Player { get; set; }
        public OperatorViewModel Operator { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}
