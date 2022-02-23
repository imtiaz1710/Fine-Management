namespace FineManagement.Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateOnly Date { get; set; }
        public string? Note { get; set; }
        public UserTeam? UserTeam { get; set; }
    }
}
