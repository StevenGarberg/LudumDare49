using System.Collections.Generic;
using System.Linq;
using LudumDare49.API.Models.Requests;

namespace LudumDare49.API.Models.Responses
{
    public class PlayerMatchResultResponse
    {
        public PlayerMatchResultResponse(string id, IEnumerable<MatchResults> results)
        {
            var matchResultsEnumerable = results as MatchResults[] ?? results.ToArray();
            Wins = matchResultsEnumerable.Where(r => id == r.WinnerId).ToList();
            Losses = matchResultsEnumerable.Where(r => id == r.LoserId).ToList();
        }
        public IEnumerable<MatchResults> Wins { get; }
        public IEnumerable<MatchResults> Losses { get; }
    }
}