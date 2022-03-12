using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.Models
{
    public class ApplicationContext: IdentityDbContext<User>
    {
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Events> Events { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
