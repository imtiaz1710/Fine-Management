namespace FineManagement.Application.Responses
{
    public class UserTeamResponse
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}
