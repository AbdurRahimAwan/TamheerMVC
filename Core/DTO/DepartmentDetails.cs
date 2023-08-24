namespace Core.Entity
{
    public class DepartmentDetails : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CoordinatorName { get; set; }
        public string? SupervisorName { get; set; }
        public ICollection<TraineeRows>? traineeRows { get; set; } = new List<TraineeRows>();
        public ICollection<JobRows>? jobRows { get; set; } = new List<JobRows>();

    }
}
