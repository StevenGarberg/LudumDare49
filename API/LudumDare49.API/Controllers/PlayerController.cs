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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id, [FromQuery] bool useOwnerId = false)
        {
           return Ok(await _playerService.GetByIdAsync(id, useOwnerId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _playerService.GetAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Upsert([FromBody] Player request)
        {
            return Ok(await _playerService.UpsertAsync(request));
        }
        
        [HttpPut("{id}/settings")]
        public async Task<IActionResult> UpdateSettings([FromRoute] string id, [FromBody] PlayerSettings request, [FromQuery] bool useOwnerId = false)
        {
            return Ok(await _playerService.UpdateSettings(id, request, useOwnerId));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id, [FromQuery] bool useOwnerId = false)
        {
            await _playerService.Delete(id, useOwnerId);
            return NoContent();
        }
    }
}