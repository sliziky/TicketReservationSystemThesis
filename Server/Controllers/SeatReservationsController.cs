using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Commands;
using TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Queries;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeatReservationsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SeatReservationsController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }
    // GET: api/<UsersController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SeatReservation>>> Get()
    {
      var users = await _mediator.Send(new GetSeatReservationsQuery());
      return Ok(users);
    }

    [HttpPost("{id}/seats")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SeatReservation>>> AddSeatToSeatReservation(int id, [FromBody] Seat seat)
    {
      var users = await _mediator.Send(new AddSeatToSeatReservationCommand() { Id = id, Seat = seat});
      return Ok(users);
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SeatReservation>> Delete(int id)
    {
      var r = await _mediator.Send(new DeleteSeatReservationCommand() { Id = id });
      if (r == null) { return NotFound(); }
      return Ok();
    }
  }
}
