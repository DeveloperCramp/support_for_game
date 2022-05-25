using AutoMapper;
using Db;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessagesDbStorage messagesDbStorage;
        private readonly IMapper mapper;
        public MessagesController(IMessagesDbStorage messagesDbStorage, IMapper mapper)
        {
            this.messagesDbStorage = messagesDbStorage;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var dbMessages = await messagesDbStorage.GetAllAsync();
            var models = mapper.Map<List<MessageViewModel>>(dbMessages);
            return View(models);
        }
    }
}
