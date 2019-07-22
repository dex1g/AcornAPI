using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Helpers;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;

namespace Acorn.BL.Services
{

    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _usersRepository.Authenticate(username, password);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _usersRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _usersRepository.GetById(id);
        }

        public async Task<User> Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AuthenticationException(Resources.PasswordReqString);

            if (await _usersRepository.IsUsernameTaken(user.Username))
                throw new AuthenticationException(Resources.UsernameTakenString, user.Username);

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return await _usersRepository.Create(user);
        }

        public async Task Update(User userParam, string password = null)
        {
            var user = await _usersRepository.GetById(userParam.Id);

            if (user == null)
                throw new AuthenticationException(Resources.UserNotFoundString);

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (await _usersRepository.IsUsernameTaken(userParam.Username))
                    throw new AuthenticationException(Resources.UsernameTakenString, userParam.Username);
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            await _usersRepository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _usersRepository.Delete(id);
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException(Resources.ValEmptyOrWhitespaceString, nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException(Resources.ValEmptyOrWhitespaceString, nameof(password));
            if (storedHash.Length != 64) throw new ArgumentException(Resources.PassHashInvalidLengthString, nameof(storedHash));
            if (storedSalt.Length != 128) throw new ArgumentException(Resources.PassSaltInvalidLengthString, nameof(storedSalt));

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}