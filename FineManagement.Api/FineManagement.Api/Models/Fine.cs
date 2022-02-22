namespace FineManagement.Api.Models
{
    public class Fine
    {
        int Id { get; set; }
        string? FineType { get; set; }
        string? FineAmount { get; set; }
        DateOnly Date { get; set; }
        string? Note { get; set; }
    }
}
