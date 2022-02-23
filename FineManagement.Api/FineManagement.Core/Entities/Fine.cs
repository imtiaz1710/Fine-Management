namespace FineManagement.Core.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public string? FineType { get; set; }
        public string? FineAmount { get; set; }
        public DateOnly Date { get; set; }
        public string? Note { get; set; }
        public UserTeam? UserTeam { get; set; }
    }
}
