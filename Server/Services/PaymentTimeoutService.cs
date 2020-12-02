using Hangfire;
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
    public class PaymentTimeoutService : IPaymentTimeoutService, IHostedService, IDisposable
    {
        private Timer _timer;
        private string _paymentIntent;
        private int _reservationId;
        private HttpClient _client;
        private IHttpContextAccessor _httpContextAccessor;

        public PaymentTimeoutService()
        {
            
        }

        public Task StartAsync(string intent, int reservationId, string apiToken)
        {

            //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
            _reservationId = reservationId;
            _paymentIntent = intent;
            var timeInMinutes = 1;
            //_timer = new Timer(DoWork, null, timeInMinutes * 60 * 10000, Timeout.Infinite);
            var jobId = BackgroundJob.Schedule(
                () => DoWork(reservationId, intent, apiToken),
                TimeSpan.FromSeconds(40));
            return Task.CompletedTask;
        }

        public async Task DoWork(int reservationId, string intentId, string apiToken)
        {
            _client = new HttpClient() { BaseAddress = new Uri("https://localhost:44379") };
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
            var res = await _client.GetFromJsonAsync<Reservation>("api/reservations/" + reservationId);
            if (res.Status == Reservation.ReservationStatus.Paid) { await StopAsync(); return; }

            var response = await _client.PostAsync("https://api.stripe.com/v1/payment_intents/" + intentId + "/cancel", null);
            var body = await response.Content.ReadAsStringAsync();
            var response2 = await _client.DeleteAsync("api/reservations/" + reservationId);
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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
