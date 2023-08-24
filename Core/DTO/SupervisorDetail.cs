namespace Core.Entity
{
    public class SupervisorDetails
    {
        public string Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string Email { get; set; } = null!;
        public Department? Department { get; set; } = null!;
        public ICollection<DepartmentRows> DepartmentRows { get; set; } = new List<DepartmentRows>();
    }
}
