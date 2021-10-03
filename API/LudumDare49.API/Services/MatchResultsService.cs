using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Models.Requests;
using LudumDare49.API.Models.Responses;
using LudumDare49.API.Repositories;

namespace LudumDare49.API.Services
{
    public class MatchResultsService
    {
        private readonly MatchResultsRepository _matchResultsRepository;

        public MatchResultsService(MatchResultsRepository matchResultsRepository)
        {
            _matchResultsRepository = matchResultsRepository;
        }
        
        public async Task<PlayerMatchResultResponse> GetById(string id)
        {
            try
            {
                var totalResults = await _matchResultsRepository.GetByIdAsync(id);
                return new PlayerMatchResultResponse(id, totalResults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<IEnumerable<MatchResults>> Get()
        {
            try
            {
                return await _matchResultsRepository.GetAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MatchResults> CreateAsync(MatchResults request)
        {
            try
            {
                return await _matchResultsRepository.CreateAsync(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}