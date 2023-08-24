using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class TraineesCoordinator : BaseEntity
    {
        public int Id { get; set; }
        public ApplicationUser? Coordinator { get; set; }
        [ForeignKey("Coordinator")]
        public string? CoordinatorId { get; set; }

        public TraineeProfile? Trainee { get; set; }
        [ForeignKey("Trainee")]
        public int? TraineeId { get; set; }
    }
}
