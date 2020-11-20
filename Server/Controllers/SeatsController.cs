using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.HallCQRS.Queries;
using TicketReservationSystem.Server.CQRS.SeatsCQRS.Commands;
using TicketReservationSystem.Server.CQRS.SeatsCQRS.Queries;
using TicketReservationSystem.Shared.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeatsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SeatsController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }
    // GET: api/<HallsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Seat>>> Get()
    {
      var halls = await _mediator.Send(new GetSeatsQuery());
      return Ok(halls);
    }

    //// GET api/<HallsController>/5
    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<ActionResult<Hall>> Get(int id)
    //{
    //  var hall = await _mediator.Send(new GetSeatQuery() { Id = id });
    //  if (hall == null) { return NotFound(); }
    //  return Ok(hall);
    //}

    // POST api/<HallsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Seat>> PostAsync([FromBody] Seat seat)
    {
      var foundSeat = await _mediator.Send(new AddSeatCommand() { Seat = seat });
      if (foundSeat == null) { return Conflict(); }
      return Ok(seat);
    }

    // PUT api/<HallsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<HallsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Seat>> Delete(int id)
    {
      var seat = await _mediator.Send(new DeleteSeatCommand() { Id = id });
      if (seat == null) { return NotFound(); }
      return Ok();
    }
  }
}
