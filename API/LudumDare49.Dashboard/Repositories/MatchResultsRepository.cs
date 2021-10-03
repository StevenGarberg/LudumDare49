using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Models.Requests;
using LudumDare49.API.Models.Responses;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace LudumDare49.Dashboard.Repositories
{
    public class MatchResultsRepository
    {
        private readonly IConfiguration _config;

        private readonly IRestClient _restClient;
        public MatchResultsRepository(IRestClient restClient, IConfiguration config)
        {
            _restClient = restClient;
            _config = config;
        }
        
        public async Task<PlayerMatchResultResponse> GetById(string id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<MatchResults>> Get()
        {
            var request = new RestRequest("/match/results");
            var response = await _restClient.ExecuteAsync<List<MatchResults>>(request);

            return response.Data;
        }
    }
}