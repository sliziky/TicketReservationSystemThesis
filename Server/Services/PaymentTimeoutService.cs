using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Services
{
    public class PaymentTimeoutService : IPaymentTimeoutService
    {
        private Timer _timer;

        public Task StartAsync()
        {
            Console.WriteLine("Starting timer");
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public async void DoWork(object state)
        {
            Console.WriteLine("Doing work");
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
