using Microsoft.EntityFrameworkCore;
using PRJ2.API.Data;
using PRJ2.API.Models;

namespace PRJ2.API.Repositories
{
    public class SQLAppointmentRepository : IAppointmentRepository
    {
        private readonly HCMSDbContext dbcontext;

        public SQLAppointmentRepository(HCMSDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<List<Appointment>>GetAllAsync()
        {
            return await dbcontext.Appointmentsss.ToListAsync();
        }

       

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await dbcontext.Appointmentsss.FirstOrDefaultAsync(x => x.AppointmentId == id);
        }
        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await dbcontext.Appointmentsss.AddAsync(appointment);
            await dbcontext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> UpdateAsync(Appointment appointment)
        {
            var existingapp= await dbcontext.Appointmentsss.FirstOrDefaultAsync(x=>x.AppointmentId == appointment.AppointmentId);
            if(existingapp == null)
            {
                return null;
            }
            existingapp.AppointmentId = appointment.AppointmentId;
            existingapp.PatientId = appointment.PatientId;
            existingapp.DoctorId = appointment.DoctorId;
            existingapp.AppointmentDate = appointment.AppointmentDate;
            existingapp.Status = appointment.Status;

            return existingapp;
        }

       

        public async Task<Appointment> DeleteAsync(Guid id)
        {
            var existingid= await dbcontext.Appointmentsss.FirstOrDefaultAsync(x=> x.AppointmentId == id);
            if(existingid == null)
            {
                return null;
            }
            dbcontext.Appointmentsss.Remove(existingid);
             await dbcontext.SaveChangesAsync();
            return existingid; 
        }

      
    }
}
