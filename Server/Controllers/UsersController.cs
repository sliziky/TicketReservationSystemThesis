using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.AdminCQRS.Queries;
using TicketReservationSystem.Server.CQRS.Queries;
using TicketReservationSystem.Server.CQRS.UserCQRS;
using TicketReservationSystem.Shared.Domain;
using TicketReservationSystem.Shared.DTO;
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

        [HttpPost("authenticateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> AuthenticateUser([FromBody] User user)
        {
            var userAuthenticated = await _mediator.Send(new AuthenticateUserCommand() {  User = user});
            return Ok(userAuthenticated);
        }

        //GET api/<UsersController>/5
        [HttpGet("{id:int}")]
        public async Task<User> Get(int id)
        {
            return await _mediator.Send(new GetUserQueryId() { Id = id });
        }
        [HttpGet("{id}/isadmin")]
        public async Task<bool> IsUserAdmin(int id)
        {
            return await _mediator.Send(new GetIsUserAdminQuery() {UserId = id });
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Get(string email)
    {
      var user = await _mediator.Send(new GetUserQueryEmail() { Email = email });
      if (user == null) { return NotFound(); }
      return Ok(_mapper.Map<UserDTO>(user));
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<ActionResult<User>> PostAsync([FromBody] User user)
    {
      var userFound = await _mediator.Send(new AddUserCommand { User = user });
      if (userFound == null) { return Conflict(); }
      return Ok();
    }

        [HttpPost("changepassword")]
        public async Task<ActionResult<User>> ChangePassword([FromBody] User user)
        {
            var userFound = await _mediator.Send(new ChangePasswordForUserCommand { User = user });
            if (userFound == null) { return Ok(); }
            return Ok();
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
