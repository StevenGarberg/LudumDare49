using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Models.Requests;
using LudumDare49.API.Models.Responses;

namespace LudumDare49.Dashboard.Repositories
{
    public class MatchResultsRepository
    {
        private string testUrl = "";

        public MatchResultsRepository()
        {
            
        }

        public async Task<PlayerMatchResultResponse> GetById(string id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<MatchResults>> Get()
        {
            throw new NotImplementedException();
        }
    }
}