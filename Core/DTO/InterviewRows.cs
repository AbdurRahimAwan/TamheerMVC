using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class InterviewRows : BaseEntity
    {
        public int Id { get; set; }
        public int jobId { get; set; }
        public string? userID { get; set; }
        public string? fullName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? locationUrl { get; set; }
        public string? IqamaNumber { get; set; }
        public string? ProfilePic { get; set; } 
        public string? CV_filePath { get; set; }
        public string? JobStatus { get; set; }
        public int JobStatusId { get; set; }

    }
}
