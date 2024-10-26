using Microsoft.AspNetCore.Mvc;
using EventManagement.BLL.Services.Contracts;
using EventManagement.API.Utility;
using EventManagement.DTO;
namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var rsp = new Response<List<UserDto>>();


            try
            {
                rsp.status = true;
                rsp.data = await userService.ListUsers();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            var rsp = new Response<UserDto>();

            try
            {
                rsp.status = true;
                rsp.data = await userService.CreateUser(user);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.mesage = ex.Message;
            }

            return Ok(rsp);
        }


    }
}
