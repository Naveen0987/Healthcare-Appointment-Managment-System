namespace HealtcareManagment.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string AvailabilityHours { get; set; }
        public User User { get; set; } // FK to User table
    }
}
