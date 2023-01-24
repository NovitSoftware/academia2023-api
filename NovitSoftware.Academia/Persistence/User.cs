﻿using System;
using System.Collections.Generic;

namespace NovitSoftware.Academia.Persistence
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
    }
}