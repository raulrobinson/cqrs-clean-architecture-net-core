using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Application.Commands
{
    public class CreateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(string name, string email)
        {
            var user = new UserDomain { Id = new Random().Next(), Name = name, Email = email };
            await _userRepository.AddAsync(user);
        }
    }
}
