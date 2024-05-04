using EscalarRisco.Request;
using EscalarRisco.Response;
using MediatR;

namespace EscalarRisco.Commands
{
    public class ClimbCliffCommand : IRequest<ClimbCliffResponse>
    {
        public ClimbCliffRequest Request { get; set; }
    }
}

