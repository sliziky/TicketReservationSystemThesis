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

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentsController : ControllerBase
  {
    private readonly IMediator _mediator;
    public PaymentsController(IMediator mediator)
    {
      // Set your secret key. Remember to switch to your live secret key in production!
      // See your keys here: https://dashboard.stripe.com/account/apikeys
      _mediator = mediator;
      StripeConfiguration.ApiKey = "sk_test_51Hq6mILLnywEZaCh5zRv3DcYUVDlWanxIZpLFaPsu2WhLRrWAsSwcVU6xW6PtORR56XVGPwvGMF5ASFu1JB6hCoq00t5xiR1Ki";
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Payment>>> Get()
    {
      var payments = await _mediator.Send(new GetPaymentsQuery());
      return Ok(payments);
    }

    [HttpPost("create-checkout-session")]
    public ActionResult CreateCheckoutSession([FromBody]Reservation reservation)
    {
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
              UnitAmount = reservation.Payment.TotalPrice,
              Currency = "eur",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = reservation.MovieShow.Movie.Title.ToString()
              },

            },
            Quantity = reservation.ReservationSeats.Count
          },
        },
        Mode = "payment",
        SuccessUrl = "https://localhost:44379/payment/" + reservation.ReservationId + "/success",
        CancelUrl = "https://localhost:44379/payment/" + reservation.ReservationId + "/cancel",
      };

      var service = new SessionService();
      Session session = service.Create(options);
      return Ok(JsonConvert.SerializeObject(new { id = session.Id }));
    }
  }
}
