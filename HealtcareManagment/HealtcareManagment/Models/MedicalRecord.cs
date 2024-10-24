using System.ComponentModel.DataAnnotations;

namespace HealtcareManagment.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime RecordDate { get; set; }

        
        public Doctor Doctor { get; set; }
    }
}
