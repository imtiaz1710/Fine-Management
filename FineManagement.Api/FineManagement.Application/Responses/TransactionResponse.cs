namespace FineManagement.Application.Responses
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public int UserTeamId { get; set; }
    }
}
