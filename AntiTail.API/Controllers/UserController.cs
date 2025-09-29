using AntiTail.API.Contracts;
using AntiTail.Domain.Interfaces;
using AntiTail.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AntiTail.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            List<UserEntity> userEntities = await _userService.GetUsers();

            if (userEntities.Count == 0)
            {
                return NotFound(new { message = "Users are not found"});
            }

            List<UserResponse> users = [.. userEntities.Select(u => new UserResponse(u.Id, u.Login))];

            return Ok(users);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<UserResponse>> GetUserById(long id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { message = $"User with id {id} is not found" });
            }

            return Ok(new UserResponse(user.Id, user.Login));
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] UserRequest request)
        {
            var user = await _userService.CreateUser(request.Login);

            if (user == null)
            {
                return Conflict(new {message = $"User with login {request.Login} is already exists"});
            }

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = user.Id },
                new UserResponse(user.Id, user.Login));
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<UserResponse>> UpdateUser([FromBody] UserRequest request, long id)
        {
            var user = await _userService.UpdateUser(id, request.Login);

            if (user == null)
            {
                return NotFound(new { message = $"User with id {id} is not found" });
            }

            return Ok(new UserResponse(user.Id, user.Login));
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            var user = await _userService.DeleteUser(id);

            if (!user)
            {
                return NotFound(new { message = $"User with id {id} is not found" });
            }

            return NoContent();
        }
    }
}
