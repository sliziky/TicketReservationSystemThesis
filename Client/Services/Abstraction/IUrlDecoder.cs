using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.Services.Abstraction
{
    public interface IUrlDecoder
    {
        public string Encode(string url);
        public string Decode(string url);
    }
}
