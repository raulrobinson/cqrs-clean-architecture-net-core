using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDomain>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDomain { Id = u.Id, Name = u.Name, Email = u.Email })
                .ToListAsync();
        }

        public async Task<UserDomain> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : new UserDomain { Id = user.Id, Name = user.Name, Email = user.Email };
        }

        public async Task AddAsync(UserDomain user)
        {
            var entity = new UserEntity { Id = user.Id, Name = user.Name, Email = user.Email };
            _context.Set<UserEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDomain user)
        {
            var entity = await _context.Users.FindAsync(user.Id);
            if (entity == null) return;

            entity.Name = user.Name;
            entity.Email = user.Email;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return;

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
