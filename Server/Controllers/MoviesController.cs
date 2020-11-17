using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.Commands;
using TicketReservationSystem.Server.CQRS.Queries;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;

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
    public async Task<IEnumerable<MovieDTO>> Get()
    {
      return await _mediator.Send(new GetMoviesQuery());
    }

    // GET api/<MovieController>/5
    [HttpGet("{id}")]
    public async Task<MovieDTO> Get(int id)
    {
      return await _mediator.Send(new GetMovieQuery { Id = id });
    }

    // POST api/<MovieController>
    [HttpPost]
    public async Task<ActionResult<Movie>> Post([FromBody] MovieDTO Movie)
    {
      try
      {
        Console.WriteLine(Movie);
        return await _mediator.Send(new AddMovieCommand { Movie = _mapper.Map<Movie>(Movie) });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    // PUT api/<MovieController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Movie>> PutAsync(int id, [FromBody] MovieDTO movie)
    {
      try
      {
        return await _mediator.Send(new UpdateMovieCommand { Movie = _mapper.Map<Movie>(movie), Id = id });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    // DELETE api/<MovieController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete(int id)
    {
      try
      {
        return await _mediator.Send(new DeleteMovieCommand { Id = id });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }

    }
  }
}
