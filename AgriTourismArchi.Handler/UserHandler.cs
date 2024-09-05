using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using AgriTourismArchi.Repository.Interfaces;

namespace AgriTourismArchi.Handler
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository _userRepository; // Assume you have IUserRepository for database operations

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetCurrentUser()
        {
            // Implement logic to get the current user
            // Example: return _userRepository.GetCurrentUser();
            return new UserDTO(); // Replace with actual logic
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            };
        }


      
    }
}
