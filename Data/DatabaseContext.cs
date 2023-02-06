using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace crowdfarming.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public override DbSet<IdentityUser> Users { get; set; }
}

}