using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    
    public class TicketRows : BaseEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; } = null!;
        public string Details { get; set; } = null!;
        public string? ticketStatus { get; set; }
        public string? Notes { get; set; }
        public string? TicketByName { get; set; }
        public string? TicketForName { get; set; }
        public string? ticketCategory { get; set; }
    }
}
