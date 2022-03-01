namespace FineManagement.Core.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Team>? Teams { get; set; }
    }
}
