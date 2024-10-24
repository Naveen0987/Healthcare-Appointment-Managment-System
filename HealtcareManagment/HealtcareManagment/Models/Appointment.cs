using System.Numerics;

namespace HealtcareManagment.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Scheduled";

       
        public Doctor Doctor { get; set; }
        public DateTime CreatedAt { get; set; } // New property for registration date
        public DateTime UpdatedAt { get; set; }
    }
}
