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
    public class DietController : ControllerBase
    {
        private readonly IUserService userService;
        public DietController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userService.GetByIdAync(id);

            if (!result.Success)
                return NotFound();

            return Ok(result);
        }        

        [HttpPost("Update")]
        public async Task<IActionResult> Update(User user)
        {
            var result = await userService.UpdateAsync(user);

            if (result.Success)
                return Ok(result);

            return NotFound();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.DeleteAsync(id);

            if (result.Success)
                return Ok(result);

            return NotFound();
        }
    }
}
