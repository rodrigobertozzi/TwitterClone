using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Common;

namespace Twitter.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        public Tweet(string content)
        {
            Content = content;
        }

        public string Content { get; private set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
