using Microsoft.EntityFrameworkCore;
using PRJ2.API.Data;
using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        private readonly HCMSDbContext dbcontext;

        public SQLDepartmentRepository(HCMSDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public async Task<List<Department>> GetAllAsync()
        {
            return await dbcontext.departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(Guid id)
        {
            return await dbcontext.departments.FirstOrDefaultAsync(x=>x.DepartmentId==id);
        }

        public async Task<Department> CreateAsync(Department department)
        {
             await dbcontext.departments.AddAsync(department);
             await dbcontext.SaveChangesAsync();
            return department;
        }


        public async Task<Department> UpdateAsync(Department department)
        {
            var existingdep = await dbcontext.departments.FirstOrDefaultAsync(x=> x.DepartmentId == department.DepartmentId);
            if(existingdep == null)
            {
                return null;
            }
            existingdep.DepartmentId = department.DepartmentId;
            existingdep.Departmentname = department.Departmentname;
            existingdep.Location = department.Location;
            existingdep.Depcontactno = department.Depcontactno;
            existingdep.Description = department.Description;

            await dbcontext.SaveChangesAsync();
            return existingdep; 

        }

        public async Task<Department> DeleteAsync(Guid id)
        {
            var dept = await dbcontext.departments.FirstOrDefaultAsync(x => x.DepartmentId==id);
            if(dept ==null)
            {
                return null;
            }

             dbcontext.departments.Remove(dept);
            await dbcontext.SaveChangesAsync();
            return dept;


        }
    }
}
