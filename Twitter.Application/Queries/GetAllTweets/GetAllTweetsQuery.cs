﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;

namespace Twitter.Application.Queries.GetAllTweets
{
    public class GetAllTweetsQuery : IRequest<TweetViewModel>
    {

    }
}
