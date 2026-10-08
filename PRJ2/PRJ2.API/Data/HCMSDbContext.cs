using Microsoft.EntityFrameworkCore;
using PRJ2.API.Models;



    namespace PRJ2.API.Data
    {
        public class HCMSDbContext : DbContext
        {
            public HCMSDbContext(DbContextOptions<HCMSDbContext> dbcontext)
                : base(dbcontext)
            {
            }

            public DbSet<Patients> patients { get; set; }
            public DbSet<DoctoR> doctor {  get; set; }
        }
    }



