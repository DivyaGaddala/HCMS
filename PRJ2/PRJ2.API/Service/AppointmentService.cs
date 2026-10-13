using PRJ2.API.Data;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await repository.GetAllAsync();
;            
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            return await repository.CreateAsync(appointment);
        }

        public async Task<Appointment?> UpdateAsync(Appointment appointment)
        {
          return await repository.UpdateAsync(appointment);
        }
        public async Task<Appointment?> DeleteAsync(Guid id)
        {
           return  await repository.DeleteAsync(id);
        }
      

        public async Task<bool>CancelAppointmentAsync(Guid id)
        {
            var appointment = await repository.GetByIdAsync(id);
            if (appointment == null)
            {
                return false;
            }
            if (string.Equals(
               appointment.Status?.Trim(),
              "Completed",
              StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            appointment.Status = "cancelled";
            var updateappointment = await repository.UpdateAsync(appointment);
            return updateappointment != null;

        }

       
    }
}

