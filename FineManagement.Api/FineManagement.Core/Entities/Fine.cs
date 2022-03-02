namespace FineManagement.Core.Entities
{
    public class Fine : BaseEntity<int>
    {
        public string FineType { get; set; }
        public string FineAmount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public int UserTeamId { get; set; }
        public UserTeam? UserTeam { get; set; }
    }
}
