using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Common;

namespace Twitter.Domain.Events
{
    public class FollowedCreatedEvent : DomainEvent
    {
        public Follow Item { get; private set; }

        public FollowedCreatedEvent(Follow item)
        {
            Item = item;
        }
    }
}
