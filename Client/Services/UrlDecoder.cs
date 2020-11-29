using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Client.Services.Abstraction;
using Microsoft.AspNetCore.DataProtection;

namespace TicketReservationSystem.Client.Services
{
    public class UrlDecoder : IUrlDecoder
    {
        //private readonly IDataProtector protector;

        //public UrlDecoder(IDataProtectionProvider provider)
        //{
        //    this.protector = provider.CreateProtector("EmployeesApp.EmployeesController");
        //}

        //public string DecodeUrl(string url)
        //{
        //    return protector.Protect(url);
        //}

        //public string EncodeUrl(string url)
        //{
        //    return protector.Unprotect(url);
        //}
        public string DecodeUrl(string url)
        {
            throw new NotImplementedException();
        }

        public string EncodeUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
