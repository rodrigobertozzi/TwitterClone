using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.ViewModels
{
    public class TweetViewModel
    {
        public TweetViewModel(string content)
        {
            Content = content;
        }
        public int Id { get; private set; }
        public string Content { get; private set; }
    }
}
