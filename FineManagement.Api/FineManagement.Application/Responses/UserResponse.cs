namespace FineManagement.Application.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
    }
}
