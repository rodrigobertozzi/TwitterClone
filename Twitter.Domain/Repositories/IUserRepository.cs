using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;

namespace Twitter.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> FirstAsync();
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);

    }
}
