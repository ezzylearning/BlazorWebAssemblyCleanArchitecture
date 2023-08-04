using BlazorWebAssemblyCleanArchitecture.Application.Features.Stadiums.Queries.GetAllStadiums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssemblyCleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumsController : ControllerBase
    { 
        private readonly IMediator mediator;

        public StadiumsController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetAllStadiumsQuery()));
        }
    }
}