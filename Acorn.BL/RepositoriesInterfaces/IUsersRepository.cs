using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;

namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IUsersRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<bool> IsUsernameTaken(string username);
        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
