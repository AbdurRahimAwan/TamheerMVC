namespace Core.Entity
{
    public class CoordinatorTicketsDto
    {
        public int TicketId { get; set; }
        public string TraineName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string? Details { get; set; } = null!;
        public int? ResponsId { get; set; }
        public string? Response { get; set; }
        public DateTime? ResponseCreated { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
