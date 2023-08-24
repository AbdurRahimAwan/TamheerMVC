using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class JobRows : BaseEntity
    {
        public int Id { get; set; }
        public string? userId { get; set; }
        public string? Name { get; set; } = null!;
        public string? Department { get; set; }
        public string? Coordinator { get; set; }
        public string? Supervisor { get; set; }
        public string? traineeStatusColor { get; set; }
        public string? traineeStatus { get; set; }
        public int? TraineeCount { get; set; }
        public DateTime? interviewDate { get; set; }
        public int? CountRequiredToJobs { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Applied { get; set; }
        public int? Granted { get; set; }
        public int? Rejected { get; set; }
        public int? Interview { get; set; }
        public int? RefusedCount { get; set; }
    }
}
