using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.CQRS.HallCQRS.Commands;
using TicketReservationSystem.Server.CQRS.HallCQRS.Queries;
using TicketReservationSystem.Shared.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HallsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly MyContext _context;
    public HallsController(IMediator mediator, IMapper mapper, MyContext context)
    {
      _mapper = mapper;
      _mediator = mediator;
      _context = context;
    }
    // GET: api/<HallsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Hall>>> Get()
    {
      var halls = await _mediator.Send(new GetHallsQuery());
      return Ok(halls);
    }

    // GET api/<HallsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hall>> Get(int id)
    {
      var hall = await _mediator.Send(new GetHallQuery() { Id = id });
      if (hall == null) { return NotFound(); }
      return Ok(hall);
    }

    // POST api/<HallsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Hall>> PostAsync([FromBody] Hall hall)
    {
      var foundHall = await _mediator.Send(new AddHallCommand() { Hall = hall});
      if (foundHall != null) { return Conflict(); }
      return Ok(hall);
    }

    [HttpPost("{id}/seat")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Hall>> PostSeat(int id, [FromBody] Seat seat)
    {
      var foundSeat = await _mediator.Send(new AddSeatToHallCommand() { Id = id, Seat = seat });
      if (foundSeat != null) { return Conflict(); }
      return Ok(foundSeat);
    }

    [HttpPost("{id}/movies/{movieId}/show")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Hall>> PostMovie(int id, int movieId, [FromBody] MovieShow show)
    {
      var foundSeat = await _mediator.Send(new AddMovieShowToHallCommand() { Id = id, MovieId = movieId, Show = show});
      if (foundSeat != null) { return Conflict(); }
      return Ok(foundSeat);
    }

    // PUT api/<HallsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<HallsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      var foundHall = await _mediator.Send(new DeleteHallCommand() { Id = id });
      if (foundHall == null) { return NotFound(); }
      return Ok(foundHall);
    }

    // DELETE api/<HallsController>/
    [HttpDelete]
    public async Task<ActionResult> DeleteAllAsync()
    {
      var foundHall = await _mediator.Send(new DeleteHallsCommand());
      if (foundHall == null) { return NotFound(); }
      return Ok(foundHall);
    }
  }
}
