using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.DTO; // Ensure this namespace is correct

namespace AgriTourismArchi.Handler.Interfaces
{
    public interface IUserHandler
    {
        UserDTO GetCurrentUser(); // Define methods as needed
        UserDTO GetUserById(int id); // Example method to get user by ID

        Task RegisterUserAsync(RegistrationDTO dto);
        Task<User?> AuthenticateUserAsync(LoginDTO dto);
    }
}
