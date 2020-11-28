using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Services;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MailController : ControllerBase
  {
    private readonly IMailService mailService;
    public MailController(IMailService mailService)
    {
      this.mailService = mailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendWelcomeMail([FromBody] int reservationId)
    {
      try
      {
        var request = new MailRequest() { ToEmail = "peterbolfa4@gmail.com", Subject = "Subject", Body = "" };
        await mailService.SendEmailAsync(request, reservationId);
        return Ok();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
