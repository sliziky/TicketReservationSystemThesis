using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Client.Services.Abstraction;
using Microsoft.AspNetCore.DataProtection;
using System.Web;
using System.Text;

namespace TicketReservationSystem.Client.Services
{
    public class UrlDecoder : IUrlDecoder
    {
        public string Decode(string data)
        {
            return HttpUtility.UrlDecode(data);
        }
        public string Encode(string data)
        {
            Console.WriteLine(Convert.ToBase64String(Encoding.Unicode.GetBytes(data)));
            Console.WriteLine(HttpUtility.UrlEncodeUnicode(data));
            Console.WriteLine(HttpUtility.JavaScriptStringEncode(data));
            return HttpUtility.UrlEncode(data);
        }
    }
}
