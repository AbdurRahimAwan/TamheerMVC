namespace Core.Entity
{
    public class Nationality : BaseEntity
    {
        public int Id { get; set; }
        public string ArNationalityName { get; set; } = null!;
        public string EnNationalityName { get; set; } = null!;

    }
}
