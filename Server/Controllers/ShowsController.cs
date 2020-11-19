using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.ShowCQRS.Commands;
using TicketReservationSystem.Server.CQRS.ShowCQRS.Queries;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShowsController : Controller
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ShowsController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }
    // GET: api/<HallsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MovieShow>>> Get()
    {
      var shows = await _mediator.Send(new GetShowsQuery());
      return Ok(shows);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MovieShow>>> Delete(int id)
    {
      var show = await _mediator.Send(new DeleteShowCommand() { Id = id });
      if (show == null) { return NotFound(); }
      return Ok(show);
    }
  }
}
