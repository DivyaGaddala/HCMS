namespace PRJ2.API.Models
{
    public class Prescription
    {
        public Guid PrescriptionId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string Instructions { get; set; }

        //Navigations and Relationships
        public Patients Patient { get; set; }
        public DoctoR  Doctor { get; set; }
    }
}
