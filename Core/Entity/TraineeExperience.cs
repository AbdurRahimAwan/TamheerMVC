namespace Core.Entity
{
    public class TraineeExperience : BaseEntity
    {
        public int Id { get; set; }
        public TraineeProfile? TraineeProfile { get; set; }
        public int TraineeProfileId { get; set; }
        public Experience? Experience { get; set; }
        public int ExperienceId { get; set; }
    }
}
