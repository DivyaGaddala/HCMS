namespace PRJ2.API.DTO
{
    public class UpdatePrescriptionRequestDTO
    {
        public Guid PatientId { get; set; }

        public Guid DoctorId { get; set; }

        public DateTime PrescriptionDate { get; set; }

        public string MedicineName { get; set; }

        public string Dosage { get; set; }

        public string Frequency { get; set; }

        public string Duration { get; set; }

        public string Instructions { get; set; }
    }
}
