using System;
using System.Collections.Generic;
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
                return useOwnerId ?  await _playerRepository.GetByOwnerIdAsync(id) : await _playerRepository.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Player>> GetAsync()
        {
            try
            {
                return await _playerRepository.GetAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Player> UpsertAsync(Player request)
        {
            try
            {
                if (request?.Id != null)
                {
                    var playerIdCheck = await _playerRepository.GetByIdAsync(request.Id);

                    if (playerIdCheck != null)
                    {
                        playerIdCheck.Data = request.Data;
                        return await _playerRepository.UpdateAsync(playerIdCheck);
                    }
                }

                if (request?.OwnerId == null) throw new Exception();
                
                var ownerIdCheck = await _playerRepository.GetByOwnerIdAsync(request.OwnerId);

                if (ownerIdCheck == null)
                {
                    request.Data ??= new PlayerData();
                    return await _playerRepository.CreateAsync(request);
                }
                
                ownerIdCheck.Data = request.Data;
                return await _playerRepository.UpdateAsync(ownerIdCheck);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<Player> UpdateSettings(string id, PlayerSettings request, bool userOwnerId = false)
        {
            try
            {
                var playerToUpdate = userOwnerId
                    ? await _playerRepository.GetByOwnerIdAsync(id)
                    : await _playerRepository.GetByIdAsync(id);

                playerToUpdate.Data.DisplayName = request.DisplayName;
                playerToUpdate.Data.FavoriteColor = request.FavoriteColor;
                
                return await _playerRepository.UpdateAsync(playerToUpdate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Delete(string id, bool useOwnerId = false)
        {
            try
            {
                var playerToDelete = useOwnerId ? await _playerRepository.GetByOwnerIdAsync(id) : await _playerRepository.GetByIdAsync(id);
                if (playerToDelete == null) return;
                await _playerRepository.DeleteAsync(playerToDelete);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}