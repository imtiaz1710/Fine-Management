using MediatR;

namespace FineManagement.Application.Commands
{
    public class DeleteFineCommand : IRequest<object>
    {
        public object Id { get; set; }
    }
}
