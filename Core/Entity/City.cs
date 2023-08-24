namespace Core.Entity
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }
    }
}
