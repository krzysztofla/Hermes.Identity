﻿using System;
using System.Collections.Generic;


namespace Hermes.Identity.Mongo.Documents
{
    public class UserDocument
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
