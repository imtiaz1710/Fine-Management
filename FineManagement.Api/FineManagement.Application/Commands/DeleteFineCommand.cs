using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineManagement.Application.Commands
{
    public class DeleteFineCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
