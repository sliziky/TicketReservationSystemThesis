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

namespace TicketReservationSystem.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentsController : ControllerBase
  {
    public PaymentsController()
    {
      // Set your secret key. Remember to switch to your live secret key in production!
      // See your keys here: https://dashboard.stripe.com/account/apikeys
      StripeConfiguration.ApiKey = "sk_test_51Hq6mILLnywEZaCh5zRv3DcYUVDlWanxIZpLFaPsu2WhLRrWAsSwcVU6xW6PtORR56XVGPwvGMF5ASFu1JB6hCoq00t5xiR1Ki";
    }

    [HttpPost("create-checkout-session")]
    public ActionResult CreateCheckoutSession()
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
              UnitAmount = 2000,
              Currency = "usd",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "T-shirt",
              },

            },
            Quantity = 1,
          },
        },
        Mode = "payment",
        SuccessUrl = "https://example.com/success",
        CancelUrl = "https://example.com/cancel",
      };

      var service = new SessionService();
      Session session = service.Create(options);

      return Ok(JsonConvert.SerializeObject(new { id = session.Id }));
    }
  }
}
