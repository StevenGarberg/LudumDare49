using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Models;
using LudumDare49.API.Models.Requests;
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
        
        public async Task<IEnumerable<MatchResults>> GetByWinnerIdAsync(string id)
        {
            try
            {
                return await _matchResultsRepository.GetByWinnerIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<IEnumerable<MatchResults>> GetByLoserIdAsync(string id)
        {
            try
            {
                return await _matchResultsRepository.GetByLoserIdAsync(id);
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