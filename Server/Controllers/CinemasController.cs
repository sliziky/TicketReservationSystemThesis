using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.CinemaCQRS.Commands;
using TicketReservationSystem.Server.CQRS.CinemaCQRS.Queries;
using TicketReservationSystem.Shared.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CinemasController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CinemasController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }

    // GET api/<CinemaController>
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Cinema>>> GetAllAsync()
    {
      var cinemas = await _mediator.Send(new GetCinemasQuery());
      return Ok(cinemas);
    }

    // GET api/<CinemaController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cinema>> GetAsync(int id)
    {
      var movie = await _mediator.Send(new GetCinemaQuery() { Id = id });
      if (movie == null) { return NotFound(); }
      return Ok(movie);
    }



    // POST api/<CinemaController>
    [HttpPost("{id}/hall")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Cinema>> PostHall(int id, [FromBody] Hall hall)
    {
      var hallResponse = await _mediator.Send(
        new AddHallToCinemaCommand() { Hall = hall, Id = id }
      );
      if (hallResponse == null)
      {
        return Conflict(hall);
      }
      return Ok(hallResponse);
    }

    // POST api/<CinemaController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Cinema>> Post([FromBody] Cinema cinema)
    {
      var cinemaFound = await _mediator.Send(new AddCinemaCommand() { Cinema = cinema });
      if (cinemaFound == null)
      {
        return Conflict(cinema);
      }
      return Ok(cinemaFound);
    }

    // PUT api/<CinemaController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cinema>> PutAsync(int id, [FromBody] Cinema cinema)
    {
      var cinemaFound = await _mediator.Send(new EditCinemaCommand() { Id = id, Cinema = cinema });
      if (cinemaFound == null) {
        return NotFound(cinema);
      }
      return Ok(cinema);
    }

    // DELETE api/<CinemaController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cinema>> Delete(int id)
    {
      var cinemaFound = await _mediator.Send(new DeleteCinemaCommand() { Id = id });
      if (cinemaFound == null) {
        return NotFound();
      }
      return Ok();
    }
  }
}
