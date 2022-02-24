using FineManagement.Application.Responses;
using MediatR;

namespace FineManagement.Application.Commands
{
    public class AddOrUpdateTransactionCommand : IRequest<TransactionResponse>
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public int UserTeamId { get; set; }
    }
}
