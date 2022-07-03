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
        public async Task<ActionResult<Player>> PostAsync(Player player)
        {
            var dbModel = mapper.Map<Db.Models.Player>(player);
            var result = await playerDbStorage.TryGetByTokenAsync(dbModel);

            if (result != null)
            {
                return BadRequest();
            }
            
            await playerDbStorage.AddAsync(dbModel);
            return Ok(dbModel);
        }
    }
}
