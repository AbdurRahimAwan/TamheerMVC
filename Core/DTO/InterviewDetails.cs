using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class InterviewDetails : BaseEntity
    {
        public int Id { get; set; }
        public string? TraineeName { get; set; }
        public string? JobName { get; set; }
        public string? InterviewBy { get; set; }
        public string? notes { get; set; }
        public string? locationUrl { get; set; }
        public DateTime interviewDate { get; set; }
        public string? interviewState { get; set; } //1: Sechadule, 2: Delay, 3: Passed, 4: Failed,    
    }
}
