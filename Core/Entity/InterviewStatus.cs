namespace Core.Entity
{
    public class InterviewStatus : BaseEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
}
