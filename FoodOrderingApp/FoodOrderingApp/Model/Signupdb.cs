﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Signupdb
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
