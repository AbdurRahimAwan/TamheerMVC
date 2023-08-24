using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Core.Entity
{
    public class TicketDetails : BaseEntity
    {
        public int Id { get; set; }
        public string? Subject { get; set; } = null;
        public string? Details { get; set; }
        public string? Notes { get; set; } = null;
        public string? CategoryName { get; set; } = null;
        public string? Status { get; set; } = null;
    }
}
