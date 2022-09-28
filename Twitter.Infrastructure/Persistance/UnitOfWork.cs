using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Repositories;

namespace Twitter.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly TwitterDbContext _context;
        public UnitOfWork(TwitterDbContext context, ITweetRepository tweets, IUserRepository users, IFollowRepository follows)
        {
            _context = context;
            Tweets = tweets;
            Users = users;
            Follows = follows;
        }
        public ITweetRepository Tweets { get; }
        public IUserRepository Users { get; }
        public IFollowRepository Follows { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await _transaction.RollbackAsync();
                throw new Exception("");
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
