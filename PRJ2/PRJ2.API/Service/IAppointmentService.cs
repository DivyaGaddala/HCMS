using PRJ2.API.Models;

namespace PRJ2.API.Service
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAsync();

        Task<Appointment?> GetByIdAsync(Guid id);

        Task<Appointment> CreateAsync(Appointment appointment);

        Task<Appointment?> UpdateAsync(Appointment appointment);

        Task<Appointment?> DeleteAsync(Guid id);

        Task<bool> CancelAppointmentAsync(Guid id);
    }
}
