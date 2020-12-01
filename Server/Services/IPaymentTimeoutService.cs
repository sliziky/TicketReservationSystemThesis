using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Services
{
    public interface IPaymentTimeoutService
    {
        Task StartAsync(string intent, int reservationId, string apiToken);
        void DoWork(object state);
        Task StopAsync();
    }
}
