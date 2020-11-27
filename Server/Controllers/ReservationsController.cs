using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.ReservationsCQRS.Commands;
using TicketReservationSystem.Server.CQRS.ReservationsCQRS.Queries;
using TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Commands;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReservationsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ReservationsController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }
    // GET: api/<UsersController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Reservation>>> Get()
    {
      var users = await _mediator.Send(new GetReservationsQuery());
      return Ok(users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Reservation>> Get(int id)
    {
      var reservation = await _mediator.Send(new GetReservationQuery() { Id = id});
      if (reservation == null) { return NotFound(); }
      return Ok(reservation);
    }

    [HttpPost("{id}/seatreservation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<SeatReservation>> PostSeatReservation(int id,[FromBody] SeatReservation sr)
    {
      sr.ReservationId = id;
      var users = await _mediator.Send(new AddSeatReservationCommand() { SeatReservation = sr });
      return Ok(users);
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Reservation>> Delete(int id)
    {
      var r = await _mediator.Send(new DeleteReservationCommand() { Id = id });
      if (r == null) { return NotFound(); }
      return Ok();
    }
  }
}
