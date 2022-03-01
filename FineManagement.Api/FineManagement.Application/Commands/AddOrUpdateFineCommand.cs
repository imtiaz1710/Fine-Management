using FineManagement.Application.Responses;
using MediatR;

namespace FineManagement.Application.Commands
{
    public class AddOrUpdateFineCommand : IRequest<FineResponse>
    {
        public string FineType { get; set; }
        public string FineAmount { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public int UserTeamId { get; set; }
    }
}
