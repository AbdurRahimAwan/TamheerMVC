using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class TraineeJob : BaseEntity
    {
        public int Id { get; set; }
        public Job? Job { get; set; }
        public int JobId { get; set; }
        public TraineeProfile? TraineeProfiles { get; set; }
        public int traineeProfileId { get; set; }
        public string? Notes { get; set; }
        public TraineeJobStatus State { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
    }
}
