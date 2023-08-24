namespace Core.Entity
{
    public class TicketCategory : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
