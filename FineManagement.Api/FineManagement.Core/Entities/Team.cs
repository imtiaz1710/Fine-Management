namespace FineManagement.Core.Entities
{
    public class Team : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
