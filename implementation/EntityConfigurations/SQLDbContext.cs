// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacistsSyndicateReNew.Models.Domain.Identity;
using PharmacistsSyndicateReNew.Models.Domain.Local;
using PharmacistsSyndicateReNew.Models.Local;

namespace PharmacistsSyndicateReNew.implementation.EntityConfigurations
{
    public class SQLDbContext : IdentityDbContext<ApplicationUser>
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options)
                  : base(options)
        {

        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<MainInformation> MainInformation { get; set; }
    }
}