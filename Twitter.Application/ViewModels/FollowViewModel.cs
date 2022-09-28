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
        public FollowViewModel(User followed, int followedId)
        {
            Followed = followed;
            FollowedId = followedId;
        }

        public User Followed { get; set; }
        public int FollowedId { get; set; }
    }
}
