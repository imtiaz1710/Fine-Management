namespace FineManagement.Core.Entities
{
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
