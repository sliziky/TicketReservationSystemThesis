using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.Queries;
using TicketReservationSystem.Server.CQRS.UserCQRS;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Shared.Domain;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public UsersController(IMediator mediator, IMapper mapper)
    {
      _mapper = mapper;
      _mediator = mediator;
    }
    // GET: api/<UsersController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
      var users = await _mediator.Send(new GetUsersQuery());
      return Ok(users);
    }

    // GET api/<UsersController>/5
    //[HttpGet("{id}")]
    //public async Task<User> Get(int id)
    //{
    //  return await _mediator.Send(new GetUserQueryId() { Id = id });
    //}

    // GET api/<UsersController>/5
    [HttpGet("{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Get(string email)
    {
      var user = await _mediator.Send(new GetUserQueryEmail() { Email = email });
      if (user == null) { return NotFound(); }
      return Ok(user);
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<User> PostAsync([FromBody] User user)
    {
      return await _mediator.Send(new AddUserCommand { User = user });
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
