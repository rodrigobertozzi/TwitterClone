using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;
using Twitter.Core.Entities;

namespace Twitter.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        
    }
}
