using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LudumDare49.API.Models;

namespace LudumDare49.Dashboard.Repositories
{
    public class PlayerRepository
    {
        public PlayerRepository()
        {
            
        }
        
        public async Task<Player> GetById(string id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<Player>> Get()
        {
            throw new NotImplementedException();
        }
    }
}