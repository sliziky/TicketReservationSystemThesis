
  window.stripeCheckout = function (callBackInstance, token, pkToken) {
    var stripe = window.Stripe(pkToken);
    stripe.redirectToCheckout({
      sessionId: token
    }).then(function (result) {
      // up to you
    })
  };
