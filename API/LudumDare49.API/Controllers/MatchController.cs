using System.Threading.Tasks;
using LudumDare49.API.Models.Requests;
using LudumDare49.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LudumDare49.API.Controllers
{
    [ApiController]
    [Route("match")]
    public class MatchController : ControllerBase
    {
        private PlayerService _playerService;

        public MatchController(PlayerService playerService)
        {
            _playerService = playerService;
        }
        
        [Route("results")]
        [HttpPost]
        public async Task<IActionResult> CreateResults(MatchResults results)
        {
            var winner = await _playerService.GetByIdAsync(results.WinnerId);
            var loser = await _playerService.GetByIdAsync(results.LoserId);
            winner.Data.Wins++;
            loser.Data.Losses++;
            await _playerService.UpsertAsync(winner);
            await _playerService.UpsertAsync(loser);
            return Accepted();
        }
    }
}