namespace Core.Entity
{
    public class TicketResponse : BaseEntity
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public Ticket? Ticket { get; set; }
        public int TicketId { get; set; }

        public string Response { get; set; } = null!;

    }
}
