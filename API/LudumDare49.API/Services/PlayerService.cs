using System;
using System.Threading.Tasks;
using LudumDare49.API.Models;
using LudumDare49.API.Repositories;

namespace LudumDare49.API.Services
{
    public class PlayerService
    {
        private readonly PlayerRepository _playerRepository;

        public PlayerService(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> GetByIdAsync(string id, bool useOwnerId = false)
        {
            try
            {
                if (useOwnerId) return await _playerRepository.GetByOwnerIdAsync(id);

                return await _playerRepository.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Player> Upsert(Player request)
        {
            try
            {
                if (request?.Id != null)
                {
                    var playerToUpdate = await _playerRepository.GetByIdAsync(request.Id);

                    if (playerToUpdate != null) return await _playerRepository.UpdateAsync(request);
                }
                else if (request?.OwnerId != null)
                {
                    var playerToUpdate = await _playerRepository.GetByOwnerIdAsync(request.OwnerId);

                    if (playerToUpdate != null) return await _playerRepository.UpdateAsync(request);
                }
                
                return request?.OwnerId != null ? await _playerRepository.CreateAsync(request) : null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(string id, bool userOwnerId = false)
        {
            try
            {
                if (userOwnerId)
                {
                    var playerToDelete = await _playerRepository.GetByOwnerIdAsync(id);
                    await _playerRepository.DeleteAsync(playerToDelete);
                }
                else
                {
                    var playerToDelete = await _playerRepository.GetByIdAsync(id);
                    await _playerRepository.DeleteAsync(playerToDelete);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}