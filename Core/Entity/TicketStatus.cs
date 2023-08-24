using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class TicketStatus
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
