using APIModels;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyDA2API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            this._userLogic = userLogic;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userLogic.GetAllUsers().Select(u => new UserResponse(u)).ToList());
        }
    }
}