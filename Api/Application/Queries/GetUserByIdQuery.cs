using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Application.Queries
{
    public class GetUserByIdQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDomain> ExecuteAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id) ?? throw new Exception("User not found");
        }
    }
}
