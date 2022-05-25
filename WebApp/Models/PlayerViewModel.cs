using System;

namespace WebApp.Models
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Token { get; set; }
    }
}
