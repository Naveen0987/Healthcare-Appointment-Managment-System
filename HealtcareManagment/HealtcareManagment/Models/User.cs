namespace HealtcareManagment.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; } // Patient, Doctor, Admin
        public DateTime CreatedAt { get; set; } // New property for registration date
        public DateTime UpdatedAt { get; set; } // New property for last updated date
    }
}
