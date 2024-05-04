using EscalarRisco.Data.Entities;
using MediatR;

namespace EscalarRisco.Queries
{
    public class GetElementsQuery : IRequest<List<Element>>
    { }
}



