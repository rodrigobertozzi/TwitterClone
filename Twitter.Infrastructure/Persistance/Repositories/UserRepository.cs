using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace Twitter.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TwitterDbContext _dbContext;
        private readonly string _connectionString;
        public UserRepository(TwitterDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("TwitterCs");
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var script = "DELETE FROM Users WHERE Id = @id";
            await sqlConnection.ExecuteAsync(script, new { user.Id });
        }
    }
}
