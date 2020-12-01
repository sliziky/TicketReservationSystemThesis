using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;
using static System.Net.WebRequestMethods;

namespace TicketReservationSystem.Server.Services
{
    public class PaymentTimeoutService : IPaymentTimeoutService
    {
        private Timer _timer;
        private string _paymentIntent;
        private int _reservationId;
        private HttpClient client = new HttpClient();
        private IHttpContextAccessor _httpContextAccessor;

        public PaymentTimeoutService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            client.BaseAddress = new Uri("https://" + _httpContextAccessor.HttpContext.Request.Host.Value);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "sk_test_51Hq6mILLnywEZaCh5zRv3DcYUVDlWanxIZpLFaPsu2WhLRrWAsSwcVU6xW6PtORR56XVGPwvGMF5ASFu1JB6hCoq00t5xiR1Ki");
        }

        public Task StartAsync(string intent, int reservationId)
        {
 
            _reservationId = reservationId;
            _paymentIntent = intent;
            _timer = new Timer(DoWork, null, 20000, Timeout.Infinite);
            return Task.CompletedTask;
        }

        public async void DoWork(object state)
        {
            var res = await client.GetFromJsonAsync<Reservation>("api/reservations/" + _reservationId);
            if (res.Status == Reservation.ReservationStatus.Paid) { await StopAsync(); return; }

            var response = await client.PostAsync("https://api.stripe.com/v1/payment_intents/" + _paymentIntent + "/cancel", null);
            var body = await response.Content.ReadAsStringAsync();
            await client.DeleteAsync("api/reservations/" + _reservationId);
            await StopAsync(); 
        }

        public Task StopAsync()
        {
            Console.WriteLine("Canceling work");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
