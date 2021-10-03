using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace LudumDare49.Dashboard.Repositories
{
    public class PlayerRepository
    {
        private readonly IConfiguration _config;

        private readonly IRestClient _restClient;
        public PlayerRepository(IRestClient restClient, IConfiguration config)
        {
            _restClient = restClient;
            _config = config;
        }
        
        public async Task<Player> GetById(string id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<Player>> Get()
        {
            var request = new RestRequest("/players");
            var response = await _restClient.ExecuteAsync<List<Player>>(request);

            return response.Data;
        }
    }
}