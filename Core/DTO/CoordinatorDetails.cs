namespace Core.Entity
{
    public class CoordinatorDetails
    {
        public int id {  get; set; }
        public string FullName { get; set; } = null!;
        public string CoordinatorId { get; set; } = null!;
        public DateTime? CreatedOn { get; set; } = null!;
        public string TraineeNames { get; set; } = null!;
        public string TraineeIds { get; set; } = null!;
        public int JobId { get; set; }
        public string JobName { get; set; }
    }
}
