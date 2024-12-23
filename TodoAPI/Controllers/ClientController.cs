using Business.Abstract;
using Core.Attributes.JWT;
using Entity.Domain;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DietApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService userService)
        {
            _clientService = userService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _clientService.GetByIdAsync(id);

            if (!result.Success)
                return NotFound();

            return Ok(result);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Add(ClientAddRequest request)
        {
            var result = await _clientService.AddAsync(request);

            if (!result.Success)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Client client)
        {
            var result = await _clientService.UpdateAsync(client);

            if (result.Success)
                return Ok(result);

            return NotFound();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _clientService.DeleteAsync(id);

            if (result.Success)
                return Ok(result);

            return NotFound();
        }
    }
}
