using EscalarRisco.Commands;
using EscalarRisco.Data.Entities;
using EscalarRisco.Response;
using MediatR;

namespace EscalarRisco.Handlers
{
    public class ClimbCliffCommandHandler : IRequestHandler<ClimbCliffCommand, ClimbCliffResponse>
    {

        private readonly List<Element> _elements;

        public ClimbCliffCommandHandler(List<Element> elements)
        {
            _elements = elements;
        }

        public Task<ClimbCliffResponse> Handle(ClimbCliffCommand request, CancellationToken cancellationToken)
        {
            var elementsOptimals = _elements.Where(e => e.Calories >= request.Request.CaloriesMin)
                                             .OrderBy(e => e.Weight)
                                             .ToList();

            return Task.FromResult(new ClimbCliffResponse { ElementsOptimals = elementsOptimals });
        }
    }
}
