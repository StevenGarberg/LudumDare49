using System.Collections.Generic;
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
        private MatchResultsService _matchResultsService;
        private PlayerService _playerService;

        public MatchController(MatchResultsService matchResultsService,PlayerService playerService)
        {
            _matchResultsService = matchResultsService;
            _playerService = playerService;
        }
        
        [Route("results/{winnerId}/wins")]
        [HttpGet]
        public async Task<IActionResult> GetWins([FromRoute]string winnerId)
        {
            return Ok(await _matchResultsService.GetByWinnerIdAsync(winnerId));
        }
        
        [Route("results/{loserId}/losses")]
        [HttpGet]
        public async Task<IActionResult> GetLosses(string loserId)
        {
            return Ok(await _matchResultsService.GetByLoserIdAsync(loserId));
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
            await _matchResultsService.CreateAsync(results);
            return Accepted();
        }
    }
}