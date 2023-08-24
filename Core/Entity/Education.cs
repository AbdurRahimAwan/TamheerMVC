namespace Core.Entity
{
    public class Education : BaseEntity
    {
        public int Id { get; set; }

        public string Majority { get; set; } = null!;
    }
}
