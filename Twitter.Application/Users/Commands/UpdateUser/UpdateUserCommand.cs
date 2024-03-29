﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserCommand(string name, string email, string username, string password, DateTime birthDate, string bio, string location)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            BirthDate = birthDate;
            Bio = bio;
            Location = location;
        }

        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public string Bio { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
    }
}
