namespace Core.Entity
{
    public class SupervisorRows
    {
        public string Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string Email { get; set; } = null!;
    }
}
