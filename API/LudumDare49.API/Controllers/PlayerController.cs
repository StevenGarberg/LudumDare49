using System;
using System.Threading.Tasks;
using LudumDare49.API.Models;
using LudumDare49.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LudumDare49.API.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] string id, [FromQuery] bool useOwnerId = false)
        {
           return Ok(await _playerService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> Upsert([FromBody] Player request)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] string id, [FromQuery] bool useOwnerId = false)
        {
            throw new NotImplementedException();
        }
    }
}