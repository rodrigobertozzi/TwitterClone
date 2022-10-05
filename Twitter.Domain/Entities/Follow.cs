using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Common;

namespace Twitter.Domain.Entities
{
    public class Follow : BaseEntity, IHasDomainEvent
    {
        public User Follower { get; set; }
        public int FollowerId { get; set; }
        public User Followed { get; set; }
        public int FollowedId { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
