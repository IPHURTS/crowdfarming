using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crowdfarming.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<crowdfarming.Models.User> Users { get; set; }
        
        
        
    }
}