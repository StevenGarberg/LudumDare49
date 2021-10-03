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
                if (useOwnerId) return await _playerRepository.GetByOwnerIdAsync(id);

                return await _playerRepository.GetByIdAsync(id);
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

                if (ownerIdCheck == null) return await _playerRepository.CreateAsync(request);
                
                ownerIdCheck.Data = request.Data;
                return await _playerRepository.UpdateAsync(ownerIdCheck);

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
                if (useOwnerId)
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}