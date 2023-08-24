namespace Core.Entity
{
    public class Interview : BaseEntity
    {
        public int Id { get; set; }
        public TraineeProfile? TraineeProfile { get; set; }
        public int TraineeProfileId { get; set; }
        public ApplicationUser? Interviewer { get; set; }
        public string? InterviewerId { get; set; }
        public InterviewStatus? InterviewStatus { get; set; }
        public int? InterviewStatusId { get; set; }
        public Job? Job { get; set; }
        public string? locationUrl { get; set; }
        public int JobId { get; set; }
        public string? notes { get; set; }
        public DateTime interviewDate { get; set; }  
    }
}
