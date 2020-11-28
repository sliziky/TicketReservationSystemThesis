using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Services.Security;

namespace TicketReservationSystem.Server.Services.NewFolder
{
    public class URLSecurity
    {
            
        private readonly IDataProtector protector;
        public URLSecurity(IDataProtectionProvider dataProtectionProvider, UniqueCode uniqueCode)
        {
            protector = dataProtectionProvider.CreateProtector(uniqueCode.BankIdRouteValue);
        }
        public string Decode(string data)
        {
            return protector.Protect(data);
        }
        public string Encode(string data)
        {
            return protector.Unprotect(data);
        }
    }
}
