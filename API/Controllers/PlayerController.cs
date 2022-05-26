using API.Models;
using AutoMapper;
using Db;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayersDbStorage playerDbStorage;
        private readonly IMapper mapper;

        public PlayerController(IPlayersDbStorage playerDbStorage, IMapper mapper)
        {
            this.playerDbStorage = playerDbStorage;
            this.mapper = mapper;
        }

        // Post api/player
        [HttpPost]
        public async Task<ActionResult<Player>> Post(Player player)
        {
            if (player == null)
            {
                return BadRequest();
            }
            var dbModel = mapper.Map<Db.Models.Player>(player);
            var result = await playerDbStorage.TryGetByNickNameAsync(dbModel);
            if (result != null && result.Nickname == player.Nickname)
            {
                return BadRequest();
            }
            await playerDbStorage.AddAsync(dbModel);
            return Ok(dbModel);
        }
    }
}
