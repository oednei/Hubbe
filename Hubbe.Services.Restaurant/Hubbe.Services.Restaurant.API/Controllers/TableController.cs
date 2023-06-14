using Hubbe.Services.Restaurant.Domain.Entities;
using Hubbe.Services.Restaurant.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hubbe.Services.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;

        public TableController(ITableRepository tableRepository)
        {
            this._tableRepository = tableRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(TablesEntity entity) 
        {
            if (entity == null)
                return BadRequest("valor nulo");

            await _tableRepository.Insert(entity);
            return Ok();
        }
    }
}
