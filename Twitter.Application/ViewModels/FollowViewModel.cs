using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;

namespace Twitter.Application.ViewModels
{
    public class FollowViewModel
    {
        public FollowViewModel(IEnumerable<Follow> followers)
        {
            Followers = followers;
        }

        public IEnumerable<Follow> Followers { get; set; }
    }
}
