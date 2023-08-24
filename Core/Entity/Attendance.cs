namespace Core.Entity
{
    public class Attendance : BaseEntity
    {
        public int Id { get; set; }
        public AttendanceType? AttendanceType { get; set; }
        public int AttendanceTypeId { get; set; }
        public int TraineeId { get; set; }
        public bool ApproveState { get; set; }
        public int UserType { get; set; }
        public string AttachmentFile { get; set; } = null!;
        public int ManagerId { get; set; }
        public DateTime AttendDate { get; set; }
    }
}
