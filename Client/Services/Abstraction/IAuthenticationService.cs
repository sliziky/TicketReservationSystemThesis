using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.DTO;

namespace TicketReservationSystem.Client.Services.Abstraction
{
  interface IAuthenticationService 
  {
    event Action OnChange;
    public Task<bool> AuthenticateUser(string email, string password);
    public Task<bool> IsLoggedIn();
    public Task LogOut();
    public Task<bool> IsUserAdmin();
        public UserDTO GetCurrentUser();
  }
}
