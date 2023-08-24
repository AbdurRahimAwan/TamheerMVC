namespace Core.Entity
{
    public class TicketAttachment : BaseEntity
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }

        public int UserId { get; set; }
        public Ticket? Ticket { get; set; }
        public int TicketId { get; set; }

    }
}
