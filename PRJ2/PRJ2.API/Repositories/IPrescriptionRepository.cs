using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<List<Prescription>>GetAllAsync();
        Task<Prescription?> GetByIdAsync(Guid id);
        Task<Prescription>CreateAsync(Prescription prescription);
        Task<Prescription?>UpdateAsync(Prescription prescription);
        Task<Prescription?>DeleteAsync(Guid id);
    }
}
