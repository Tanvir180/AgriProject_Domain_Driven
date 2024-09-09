using AgriTourismArchi.Aggregator.Models;

namespace AgriTourismArchi.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        // Add other methods if needed
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
