using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using AgriTourismArchi.Repository.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

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


        public async Task RegisterUserAsync(RegistrationDTO dto)
        {
            var salt = GenerateSalt();
            var hashedPassword = HashPassword(dto.Password, salt);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = $"{salt}{hashedPassword}",
                Role = "User", // Default role
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<User?> AuthenticateUserAsync(LoginDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        private string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var hashBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(hashBytes);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var salt = storedHash.Substring(0, 24); // Extract salt
            var hash = storedHash.Substring(24); // Extract hash
            var computedHash = HashPassword(password, salt);

            return computedHash == hash;
        }



    }
}
