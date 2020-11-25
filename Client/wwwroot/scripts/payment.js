
var stripe = window.Stripe("pk_test_51Hq6mILLnywEZaChdOLjvKjG8xt2CONqxPhc00RBCcKTJmCt7d0Rdr7KRqDV7ucAHYCVrHAxAk1rLF3zv98NudAt00jGum4A5a");

  window.stripeCheckout = function (callBackInstance,amount, token) {
    stripe.redirectToCheckout({
      sessionId: token
    }).then(function (result) {
      // up to you
    })
  };

