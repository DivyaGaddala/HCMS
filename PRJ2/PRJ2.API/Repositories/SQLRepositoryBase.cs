using PRJ2.API.Data;
using PRJ2.API.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}