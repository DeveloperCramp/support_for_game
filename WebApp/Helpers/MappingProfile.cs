using AutoMapper;
using Db.Models;
using WebApp.Models;

namespace WebApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminViewModel>();
            CreateMap<Player, PlayerViewModel>();
            CreateMap<PlayerViewModel, Player>();
            CreateMap<Message, MessageViewModel>();
        }
    }
}
