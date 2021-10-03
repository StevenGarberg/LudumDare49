using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Database;
using LudumDare49.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LudumDare49.API.Repositories
{
    public class PlayerRepository
    {
        private readonly LudumDare49Context _context;

        public PlayerRepository(LudumDare49Context context)
        {
            _context = context;
        }

        public async Task<Player> GetByIdAsync(string id)
        {
            id = id.ToLower();
            return await _context.Players
                .FirstOrDefaultAsync(u => u.Id.ToLower() == id);
        }

        public async Task<Player> GetByOwnerIdAsync(string ownerId)
        {
            ownerId = ownerId.ToLower();
            return await _context.Players
                .FirstOrDefaultAsync(u => u.OwnerId.ToLower() == ownerId);
        }
        
        public async Task<IEnumerable<Player>> GetAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> CreateAsync(Player player)
        {
            var timestamp = DateTime.UtcNow;
            player.CreatedAt = timestamp;
            player.UpdatedAt = timestamp;
            player.Id = Guid.NewGuid().ToString();
            player.Version = 1;
            var entityEntry = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Player> UpdateAsync(Player player)
        {
            try
            {
                var storedResource = await _context.Players.FindAsync(player.Id);
                if (player.Version != storedResource.Version)
                {
                    //throw new ConflictException(storedResource.Version, user.Version);
                }

                player.UpdatedAt = DateTime.UtcNow;
                player.Version += 1;
                _context.Players.Update(player);
                await _context.SaveChangesAsync();
                return player;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //throw new ConflictException(ex.Message);
                throw ex;
            }
        }

        public async Task DeleteAsync(Player player)
        {
            try
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //throw new ConflictException(ex.Message);
                throw ex;
            }
        }
    }
}