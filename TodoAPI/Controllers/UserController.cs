using Business.Abstract;
using Core.Aspects.Log;
using Entity.Domain;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DietApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
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
        [HttpPost("Auth")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var result = await userService.Authenticate(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userDto)
        {            
            var result = await userService.RegisterAsync(userDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
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
