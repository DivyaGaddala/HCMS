


using Microsoft.EntityFrameworkCore;
using PRJ2.API.Data;
using PRJ2.API.Models;
using System.Numerics;

namespace PRJ2.API.Repositories
{
    public class SQLDoctorRepository : IDoctoRRepository
    {
        private readonly HCMSDbContext dbcontext;

        public SQLDoctorRepository(HCMSDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<DoctoR>> GetAllAsync()
        {
            return await dbcontext.doctor.ToListAsync();
        }

        public async Task<DoctoR?> GetByIdAsync(Guid id)
        {
            return await dbcontext.doctor
                .FirstOrDefaultAsync(x => x.Id == id);
        }

   
        public async Task<DoctoR?> DeleteAsync(Guid id)
        {
            var doctor = await dbcontext.doctor
                .FirstOrDefaultAsync(x => x.Id == id);

            if (doctor == null)
            {
                return null;
            }

            dbcontext.doctor.Remove(doctor);
            await dbcontext.SaveChangesAsync();

            return doctor;
        }

        public async Task<DoctoR> CreateAsync(DoctoR doctor)
        {
            await dbcontext.doctor.AddAsync(doctor);
            await dbcontext.SaveChangesAsync();

            return doctor;
        }

       

        public async Task<DoctoR> UpdateAsync(DoctoR doctor)
        {
            var existingDoctor = await dbcontext.doctor
       .FirstOrDefaultAsync(x => x.Id == doctor.Id);

            if (existingDoctor == null)
            {
                return null;
            }

            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.PhoneNumber = doctor.PhoneNumber;
            existingDoctor.Email = doctor.Email;

            await dbcontext.SaveChangesAsync();

            return existingDoctor;
        }
    }
 }


