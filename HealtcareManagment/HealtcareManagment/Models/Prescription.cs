namespace HealtcareManagment.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string MedicineDetails { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
        
    }
}
