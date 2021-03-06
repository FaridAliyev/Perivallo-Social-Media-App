﻿using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class NavbarVM
    {
        public User User { get; set; }
        public IEnumerable<Friend> FriendRequests { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
    }
}
