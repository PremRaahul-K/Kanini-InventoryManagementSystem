using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Kanini.InventoryManagementSystem.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IManageUserActions _manageUserActions;

        public UsersController(IManageUserActions manageUserActions)
        {
            _manageUserActions = manageUserActions;
        }
        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(UserForLoginDto user)
        {
            try
            {
                var loggedInUser = await _manageUserActions.Login(user);
                return Ok(loggedInUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("UserRegistration")]
        public async Task<IActionResult> UserRegistration(UserForRegistrationDto user)
        {
            try
            {
                var registeredUser = await _manageUserActions.Register(user);
                return Created("Registred", registeredUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
