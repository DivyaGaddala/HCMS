using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public interface IDepartmentRepository
    {

        Task<List<Department> >GetAllAsync();
        Task<Department> GetByIdAsync(Guid id);
        Task<Department> CreateAsync(Department department);
        Task<Department> UpdateAsync(Department department);
        Task<Department> DeleteAsync(Guid id);

    }
}
