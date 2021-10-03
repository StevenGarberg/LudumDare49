using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudumDare49.API.Database;
using LudumDare49.API.Models;
using LudumDare49.API.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace LudumDare49.API.Repositories
{
    public class MatchResultsRepository
    {
        private readonly LudumDare49Context _context;

        public MatchResultsRepository(LudumDare49Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchResults>> GetByWinnerIdAsync(string winnerId)
        {
            winnerId = winnerId.ToLower();
            return await _context.MatchResults
                .Where(u => u.WinnerId.ToLower() == winnerId).ToListAsync();
        }
        
        public async Task<IEnumerable<MatchResults>> GetByLoserIdAsync(string loserId)
        {
            loserId = loserId.ToLower();
            return await _context.MatchResults
                .Where(u => u.LoserId.ToLower() == loserId).ToListAsync();
        }
        
        public async Task<IEnumerable<MatchResults>> GetAsync()
        {
            return await _context.MatchResults.ToListAsync();
        }

        public async Task<MatchResults> CreateAsync(MatchResults matchResults)
        {
            var timestamp = DateTime.UtcNow;
            matchResults.CreatedAt = timestamp;
            var entityEntry = await _context.MatchResults.AddAsync(matchResults);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}