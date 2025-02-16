using Api.Domain.Models;

namespace Api.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDomain>> GetAllAsync();
        Task<UserDomain> GetByIdAsync(int id);
        Task AddAsync(UserDomain user);
        Task UpdateAsync(UserDomain user);
        Task DeleteAsync(Guid id);
    }
}
