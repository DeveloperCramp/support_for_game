using AutoMapper;
using Db;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessagesDbStorage messageDbStorage;
        private readonly IMapper mapper;

        public MessageController(IMessagesDbStorage messageDbStorage, IMapper mapper)
        {
            this.messageDbStorage = messageDbStorage;
            this.mapper = mapper;
        }




    }
}

