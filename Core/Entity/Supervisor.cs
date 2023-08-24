using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class Supervisor : BaseEntity
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public ApplicationUser? User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; } = null!;

    }
}
