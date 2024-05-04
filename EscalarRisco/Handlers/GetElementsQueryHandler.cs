using EscalarRisco.Data.Entities;
using EscalarRisco.Queries;
using MediatR;

namespace EscalarRisco.Handlers
{
    public class GetElementsQueryHandler : IRequestHandler<GetElementsQuery, List<Element>>
    {
        private readonly List<Element> _elements;

        public GetElementsQueryHandler(List<Element> elements)
        {
            _elements = elements;
        }

        public Task<List<Element>> Handle(GetElementsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_elements);
        }

    }
}
