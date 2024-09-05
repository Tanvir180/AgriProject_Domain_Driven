using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.Repository.Data;
using AgriTourismArchi.Repository.Interfaces;

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
    }
}
