using System;
using System.Threading.Tasks;
using LudumDare49.API.Models;
using LudumDare49.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LudumDare49.API.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ControllerBase
    {
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] string id, [FromQuery] bool useOwnerId = false)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
    
        [HttpPut]
        public async Task<IActionResult> Upsert([FromBody] Player request)
        {
            throw new NotImplementedException();
        }
        
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] string id, [FromQuery] bool useOwnerId = false)
        {
            throw new NotImplementedException();
        }
    }
}