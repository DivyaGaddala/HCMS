using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PRJ2.API.Data
{
    public class HCMSAuthenticationDbContext :IdentityDbContext
    {
        public HCMSAuthenticationDbContext(DbContextOptions<HCMSAuthenticationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "335d4ff1-feab-4dde-9516-abdda6001f6a";
            var patientRoleId = "911208f6-72b9-4b88-9300-e8ad63548ef8";
            var doctorRoleId = "b3d4292f-320d-4955-91c7-4dc5e60d446b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Id = doctorRoleId,
                    Name = "Doctor",
                    NormalizedName = "DOCTOR",
                    ConcurrencyStamp = doctorRoleId
                },
                new IdentityRole
                {
                    Id = patientRoleId,
                    Name = "Patient",
                    NormalizedName = "PATIENT",
                    ConcurrencyStamp = patientRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }








        }
    }

