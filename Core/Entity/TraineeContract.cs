using Microsoft.AspNetCore.Http;

namespace Core.Entity
{
    public class TraineeContract : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
        public string? contractDuration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TraineeProfile? traineeProfile { get; set; }
        public int traineeProfileId { get; set; }
        public string? ContractById { get; set; }
        public ApplicationUser? ContractBy { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; } 
        public TraineeJobStatus? Status { get; set; }
        public int StatusId { get; set; }
        public Job? Job { get; set; }
        public int JobId { get; set; }
        public string? ContractFile { get; set; }
    }
}
