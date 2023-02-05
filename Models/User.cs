using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crowdfarming.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; } 
         public List<User>? Users { get; set; }
    }
}