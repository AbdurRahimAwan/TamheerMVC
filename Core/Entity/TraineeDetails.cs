using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class TraineeDetails : BaseEntity
    {
        public int Id { get; set; }
        public string? PhoneNo { get; set; }
        public string? FullName { get; set; }
        public string? EnglishName { get; set; }
        public string? ArabicName { get; set; }
        public bool Gender { get; set; }
        public string? Email { get; set; }
        public string? UserName  { get; set; }
        public string? IqamaNumber { get; set; }
        public DateTime? Iqama_Expiry_Date { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public string? ProfilePic { get; set; }
        public string? CV_CoverLetter { get; set; }
        public string? CV_filePath { get; set; }
        public bool license_State { get; set; }
        public string? Training_File_Path { get; set; }
        public bool Donation_Hours_Status { get; set; }
        public string? Donation_Hours_File_Path { get; set; }
        public string? GraduationFilePath { get; set; }
        public string Education { get; set; }
        public int TamheirStatusId { get; set; }
        public string? License_File { get; set; }
        public string? MaritalStatus { get; set; }
        public string? UserId { get; set; } = null!;
        public int Social_Duration { get; set; }
        public bool Social_Status { get; set; }
        public bool Tamheir_Status_Id { get; set; }
        public int Tamheir_Duration { get; set; }
        public ICollection<JobRows> JobRows { get; set; } = new List<JobRows>();
        public ICollection<TicketRows> ticketRows { get; set; } = new List<TicketRows>();

    }
}
