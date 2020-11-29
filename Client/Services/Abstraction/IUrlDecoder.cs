using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.Services.Abstraction
{
    public interface IUrlDecoder
    {
        public string EncodeUrl(string url);
        public string DecodeUrl(string url);
    }
}
