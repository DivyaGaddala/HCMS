using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public interface IPatientsRepository
    {
        Task<List<Patients>> GetAllAsync();
    }
}
