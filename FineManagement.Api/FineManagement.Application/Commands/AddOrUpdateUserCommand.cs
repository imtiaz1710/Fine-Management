using FineManagement.Application.Responses;
using MediatR;

namespace FineManagement.Application.Commands
{
    public class AddOrUpdateUserCommand : IRequest<UserResponse>
    {
        public string Name { get; set; }
        public string? PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
