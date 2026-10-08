using PRJ2.API.Data;
using PRJ2.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PRJ2.API.Repositories.SQLPatientsRepository
{
    public class SQLRepositoryBase : IPatientsRepository
    {
       
        private readonly HCMSDbContext dbcontext;

        public SQLRepositoryBase(  HCMSDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

       
        public async Task<List<Patients>> GetAllAsync()
        {
            return await dbcontext.patients.ToListAsync();
        }

        public async Task<Patients> GetByIdAsync(Guid id)
        {
            return await dbcontext.patients.FirstOrDefaultAsync(x => x.Id == id);
          
           
        }

        public async Task<Patients> CreateAsync(Patients patients)
        {
            await dbcontext.patients.AddAsync(patients);
            await dbcontext.SaveChangesAsync();
            return patients;

        }

       
        public async Task<Patients> UpdateAsync(Patients patients)
        {
             dbcontext.patients.Update(patients);
            await dbcontext.SaveChangesAsync();
            return patients;

        }


        public async Task<Patients?> DeleteAsync(Guid id)
        {
            var patient = await dbcontext.patients
                .FirstOrDefaultAsync(x => x.Id == id);

            if (patient == null)
            {
                return null;
            }

            dbcontext.patients.Remove(patient);
            await dbcontext.SaveChangesAsync();

            return patient;
        }
    }
}