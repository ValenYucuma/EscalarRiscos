using EscalarRisco.Commands;
using EscalarRisco.Data.Entities;
using EscalarRisco.Queries;
using EscalarRisco.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace EscalarRisco.Controllers
{
    public class ElementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ElementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetElements()
        {
            var query = new GetElementsQuery();
            var elements = await _mediator.Send(query);
            return Ok(elements);
        }

        [HttpPost]
        public async Task<IActionResult> EscalarRisco(ClimbCliffRequest request)
        {
            var command = new ClimbCliffCommand { Request = request };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
