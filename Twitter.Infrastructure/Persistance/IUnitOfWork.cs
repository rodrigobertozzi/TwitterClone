using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Repositories;

namespace Twitter.Infrastructure.Persistance
{
    public interface IUnitOfWork
    {
        ITweetRepository Tweets { get; }
        IUserRepository Users { get; }
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
    }
}
