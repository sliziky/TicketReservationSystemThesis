
window.stripeCheckout = function (callBackInstance, token, pkToken, dotNet) {

    var stripe = window.Stripe(pkToken);
    stripe.redirectToCheckout({
      sessionId: token
    }).then(function (result) {
        dotNet.invokeMethodAsync('TokenReceived', result).then(r => console.log(r))
    })
  };
