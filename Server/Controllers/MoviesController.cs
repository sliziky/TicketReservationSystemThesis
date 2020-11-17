using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.Commands;
using TicketReservationSystem.Server.CQRS.Queries;
using TicketReservationSystem.Shared.DTO;
using TicketReservationSystem.Shared.Domain;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public MoviesController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }

    // GET: api/<MovieController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> Get()
    {
      var movies = await _mediator.Send(new GetMoviesQuery());
      return Ok(movies);
    }

    // GET api/<MovieController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovieDTO>> Get(int id)
    {
      var movie = await _mediator.Send(new GetMovieQuery { Id = id });
      if (movie == null) { return NotFound(movie); }
      return Ok(movie);
    }

    // POST api/<MovieController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Movie>> Post([FromBody] MovieDTO Movie)
    {
      var movie = await _mediator.Send(new AddMovieCommand { Movie = _mapper.Map<Movie>(Movie) });
      if (movie != null) {
        return Conflict(movie);
      }
      return Ok(movie);
    }

    // PUT api/<MovieController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Movie>> PutAsync(int id, [FromBody] MovieDTO movie)
    {
      var movieFound = await _mediator.Send(new UpdateMovieCommand { Movie = _mapper.Map<Movie>(movie), Id = id });
      if (movieFound == null) {
        return NotFound(movieFound);
      }
      return Ok(movieFound);
    }

    // DELETE api/<MovieController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Unit>> Delete(int id)
    {
      var movieFound = await _mediator.Send(new DeleteMovieCommand { Id = id });
      if (movieFound == null)
      {
        return NotFound(movieFound);
      }
      return Ok(movieFound);
    }
  }
}
