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

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest received)
        {
            var user = received.ToEntity();
            var resultLogic = _userLogic.CreateUser(user);
            var result = new UserResponse(resultLogic);

            return CreatedAtAction(nameof(CreateUser), new { id = result.Id }, result);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userLogic.GetAllUsers().Select(u => new UserResponse(u)).ToList());
        }
    }
}