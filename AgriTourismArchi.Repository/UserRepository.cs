using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.Repository.Data;
using AgriTourismArchi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgriTourismArchi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        // Implement other methods if needed

        public async Task AddAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
