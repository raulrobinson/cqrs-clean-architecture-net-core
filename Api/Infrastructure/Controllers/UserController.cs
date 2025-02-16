using Api.Application.Commands;
using Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Infrastructure.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GetUserByIdQuery _getUserByIdQuery;
        private readonly CreateUserCommand _createUserCommand;

        public UserController(GetUserByIdQuery getUserByIdQuery, CreateUserCommand createUserCommand)
        {
            _getUserByIdQuery = getUserByIdQuery;
            _createUserCommand = createUserCommand;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _getUserByIdQuery.ExecuteAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string email)
        {
            await _createUserCommand.ExecuteAsync(name, email);
            return Created("", null);
        }
    }
}
