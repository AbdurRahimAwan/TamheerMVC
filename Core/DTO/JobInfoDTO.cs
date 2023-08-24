namespace Core.Entity
{
    public class JobInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }
        public int CountRequiredToJobs { get; set; }
        public int TraineeCount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InterViewDate { get; set; }
        public string GoogleMapLink { get; set; } = null!;
        public string ExplaningOfTranningTask { get; set; } = null!;
        public int? JobStatusId { get; set; }
        public int Applied { get; set; }
        public int Granted { get; set; }
        public int Rejected { get; set; }
        public int Interview { get; set; }
        public int RefusedCount { get; set; }

    }
}
