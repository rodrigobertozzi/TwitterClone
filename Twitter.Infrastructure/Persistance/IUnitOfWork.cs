using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Repositories;

namespace Twitter.Infrastructure.Persistance
{
    public interface IUnitOfWork
    {
        ITweetRepository Tweets { get; }
        IUserRepository Users { get; }
        IFollowRepository Follows { get; }
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
    }
}
