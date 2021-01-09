using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TicketReservationSystem.Shared.Domain;
using MediatR;
using TicketReservationSystem.Server.CQRS.PaymentsCQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using TicketReservationSystem.Server.Services;
using System.Net.Http;
using System.Net.Http.Json;
using TicketReservationSystem.Server.CQRS.CinemaCQRS.Queries;
using TicketReservationSystem.Server.CQRS.PaymentsCQRS.Commands;
using System.Configuration;

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IPaymentTimeoutService _service;
    private IHttpContextAccessor _httpContextAccessor;
    private readonly IStripeClient client;
    public PaymentsController(IMediator mediator, IPaymentTimeoutService service, IHttpContextAccessor httpContextAccessor)
    {
      // Set your secret key. Remember to switch to your live secret key in production!
      // See your keys here: https://dashboard.stripe.com/account/apikeys
      _mediator = mediator;
      _service = service;
      _httpContextAccessor = httpContextAccessor;
      }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Payment>>> Get()
    {
      var payments = await _mediator.Send(new GetPaymentsQuery());
      return Ok(payments);
    }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Payment>>> Get(int id)
        {
            var payment = await _mediator.Send(new GetPaymentQuery() { Id = id});
            if (payment != null)
            {
                return Ok(payment);
            }
            return NotFound();
        }

        [HttpPost("{id}/addsessionid")]
        public async Task<ActionResult<Payment>> AddSessionId(int id, [FromBody]string sessionId)
        {
            var payment = await _mediator.Send(new AddSessionIdCommand() { PaymentId = id, Id = sessionId });
            if (payment != null) { return Ok(payment); }
            return NotFound();
        }


    [HttpPost("create-checkout-session")]
    public async Task<ActionResult> CreateCheckoutSessionAsync([FromBody]Reservation reservation)
    {
            var cinema = await _mediator.Send(new GetFirstCinemaQuery());
            StripeConfiguration.ApiKey = cinema.GatewayApiSecretKey;
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
            {
            new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount = (long)reservation.Payment.TotalPrice,
              Currency = "eur",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = reservation.MovieShow.Movie.Title.ToString()
              },

            },
            Description = "Payment will expire at " + reservation.Payment.Created.AddMinutes(7).ToString(),
            Quantity = reservation.ReservationSeats.Count
          },
        },
        Mode = "payment",
        SuccessUrl = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/payment/" + reservation.PaymentId  + "/success?sessionId={CHECKOUT_SESSION_ID}",
        CancelUrl = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/payment/" + reservation.PaymentId + "/cancel?sessionId={CHECKOUT_SESSION_ID}",
      };

      var service = new SessionService();
      Session session = service.Create(options);
      await _service.StartAsync(session.PaymentIntentId, reservation.ReservationId, cinema.GatewayApiSecretKey);
      return Ok(JsonConvert.SerializeObject(new { id = session.Id, paymentIntent = session.PaymentIntentId }));
    }
  }
}
