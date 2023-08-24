namespace Core.Entity
{
    public class Area : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
