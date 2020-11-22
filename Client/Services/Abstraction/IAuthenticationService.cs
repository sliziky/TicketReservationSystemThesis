using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.Services.Abstraction
{
  interface IAuthenticationService 
  {
    public Task<bool> AuthenticateUser(string email, string password);
    public bool IsLoggedIn();
    public void LogOut();
  }
}
