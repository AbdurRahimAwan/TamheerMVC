namespace Core.Entity
{
    public class DepartmentRows:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Supervisor { get; set; }
        public string? Coordinator { get; set; }
        public int? JobCount { get; set; }
        public int? TraineeCount { get; set; }
    }
}
