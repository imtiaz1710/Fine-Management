namespace FineManagement.Core.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
