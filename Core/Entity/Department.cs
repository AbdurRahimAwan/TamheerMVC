using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ApplicationUser? Coordinator { get; set; }
        public string CoordinatorId { get; set; } = null!;
        public string? Notes { get; set; }

    }
}
