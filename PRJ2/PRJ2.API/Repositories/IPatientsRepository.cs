using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public interface IPatientsRepository
    {
        Task<List<Patients>> GetAllAsync();

        Task<Patients?> GetByIdAsync(Guid id);

        Task<Patients> CreateAsync(Patients patients);

        Task<Patients?> UpdateAsync(Patients patients);
        Task<Patients> DeleteAsync( Guid id);

    }
}
