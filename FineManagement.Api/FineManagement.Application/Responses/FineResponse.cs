namespace FineManagement.Application.Responses
{
    public class FineResponse
    {
        public int Id { get; set; }
        public string FineType { get; set; }
        public int FineAmount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public int UserTeamId { get; set; }
    }
}
