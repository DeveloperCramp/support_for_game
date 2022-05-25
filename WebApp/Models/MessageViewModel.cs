using System;

namespace WebApp.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public PlayerViewModel Player { get; set; }
        public AdminViewModel Admin { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}
