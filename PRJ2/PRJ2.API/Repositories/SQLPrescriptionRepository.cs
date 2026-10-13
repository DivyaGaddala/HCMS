using PRJ2.API.Data;
using PRJ2.API.Models;
using Microsoft.EntityFrameworkCore;
namespace PRJ2.API.Repositories
{
    public class SQLPrescriptionRepository : IPrescriptionRepository
    {

        private readonly HCMSDbContext dbContext;

        public SQLPrescriptionRepository(HCMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       

        public async Task<Prescription> GetByIdAsync(Guid id)
        {
            return await dbContext.prescription
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.PrescriptionId == id);
        }

        public async  Task<Prescription>CreateAsync(Prescription prescription)
        {
            await dbContext.prescription.AddAsync(prescription);
            await dbContext.SaveChangesAsync();

            return prescription;
        }

        public async  Task<Prescription> UpdateAsync(Prescription prescription)
        {

            var existingPrescription = await dbContext.prescription
        .FirstOrDefaultAsync(p =>
            p.PrescriptionId == prescription.PrescriptionId);

            if (existingPrescription == null)
            {
                return null;
            }

            existingPrescription.PatientId = prescription.PatientId;
            existingPrescription.DoctorId = prescription.DoctorId;
            existingPrescription.PrescriptionDate = prescription.PrescriptionDate;
            existingPrescription.MedicineName = prescription.MedicineName;
            existingPrescription.Dosage = prescription.Dosage;
            existingPrescription.Frequency = prescription.Frequency;
            existingPrescription.Duration = prescription.Duration;
            existingPrescription.Instructions = prescription.Instructions;

            await dbContext.SaveChangesAsync();

            return existingPrescription;

        }

        public async Task<Prescription?> DeleteAsync(Guid id)
        {
            var prescription = await dbContext.prescription
                 .FirstOrDefaultAsync(p => p.PrescriptionId == id);

            if (prescription == null)
            {
                return null;
            }

            dbContext.prescription.Remove(prescription);
            await dbContext.SaveChangesAsync();

            return prescription;
        }

        public async Task<List<Prescription>> GetAllAsync()
        {
            return await dbContext.prescription
       .Include(p => p.Patient)
       .Include(p => p.Doctor)
       .ToListAsync();
        }
    }
}
