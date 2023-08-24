namespace Core.Entity
{
    public class TraineeJobStatus : BaseEntity
    {
        public int Id { get; set; }
        public string TStatusName { get; set; } = null!;
        public string? TStatusColor { get; set; } = null!;
    }
}
