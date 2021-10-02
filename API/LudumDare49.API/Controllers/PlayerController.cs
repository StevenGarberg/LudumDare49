using System;
using System.Threading.Tasks;
using LudumDare49.API.Models;
using LudumDare49.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LudumDare49.API.Controllers
{
    public class PlayerController : ControllerBase
    {
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            throw new NotImplementedException();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(string id, [FromBody] PlayerCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}