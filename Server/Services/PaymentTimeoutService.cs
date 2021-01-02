using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
    public class PaymentTimeoutService : IPaymentTimeoutService, IHostedService
    {
        private HttpClient _client;
        private IConfiguration _config;

        public PaymentTimeoutService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public Task StartAsync(string intent, int reservationId, string apiToken)
        {

            var jobId = BackgroundJob.Schedule(
                () => DoWork(reservationId, intent, apiToken),
                TimeSpan.FromSeconds(120));
            return Task.CompletedTask;
        }

        public async Task DoWork(int reservationId, string intentId, string apiToken)
        {
            _client = new HttpClient() { BaseAddress = new Uri(_config.GetConnectionString("URL"))};
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
            var res = await _client.GetFromJsonAsync<Reservation>("api/reservations/" + reservationId);
            if (res.Status == Reservation.ReservationStatus.Paid) { return; }

            var response = await _client.PostAsync("https://api.stripe.com/v1/payment_intents/" + intentId + "/cancel", null);
            await _client.DeleteAsync("api/reservations/" + reservationId);
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
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
