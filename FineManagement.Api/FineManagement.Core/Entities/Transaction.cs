namespace FineManagement.Core.Entities
{
    public class Transaction : IEntity<int>
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public UserTeam? UserTeam { get; set; }
    }
}
