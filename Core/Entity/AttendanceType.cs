namespace Core.Entity
{
    public class AttendanceType : BaseEntity
    {
        public int Id { get; set; }
        public string AttendTypeName { get; set; } = null!;
    }
}
