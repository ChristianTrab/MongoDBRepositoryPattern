using System;
using System.Collections.Generic;
using System.Text;

namespace MongoCore.Entities
{
    public class CustomEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TestInt { get; set; }
    }
}
