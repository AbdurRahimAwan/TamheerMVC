using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class Ticket : BaseEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; } = null!;
        public string Details { get; set; } = null!;
        public TicketStatus? Status { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public string? Notes { get; set; }
        public ApplicationUser? CreatedFor { get; set; }
        public string? CreatedForId { get; set; }
        public TicketCategory? TicketCategory { get; set; }
        public int TicketCategoryId { get; set; }
    }
}
