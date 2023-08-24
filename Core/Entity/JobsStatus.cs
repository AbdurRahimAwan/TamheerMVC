namespace Core.Entity
{
    public class JobsStatus : BaseEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
}
