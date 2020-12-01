using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TicketReservationSystem.Client.Services.Abstraction;
using TicketReservationSystem.Shared.Domain;
using TicketReservationSystem.Shared.DTO;
using static System.Net.WebRequestMethods;

namespace TicketReservationSystem.Client.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    public AuthenticationService(HttpClient http)
    {
      User = null;
      Http = http;
    }

    public HttpClient Http { get; set; }
    public UserDTO User { get; set; } = null;

    public event Action OnChange;
        public bool IsAdmin { get; set; } = false;

        public async Task<bool> AuthenticateUser(string email, string password) {
      var response = await Http.PostAsJsonAsync<User>("api/users/authenticateUser", new User() { Email = email, Password =password });
      var body = await response.Content.ReadAsStringAsync();
      var authenticated = JsonConvert.DeserializeObject<bool>(body);
      if (authenticated) {
        User = await Http.GetFromJsonAsync<UserDTO>("api/users/" + email);
        IsAdmin = await Http.GetFromJsonAsync<bool>("api/users/" + User.Id + "/isadmin");
       }
      InvokeEvent();
      return User != null;
    }
    public bool IsLoggedIn() {
      return User != null;
    }
    public void LogOut() {
      InvokeEvent();
      User = null;
    }
    private void InvokeEvent() => OnChange?.Invoke();

        public bool IsUserAdmin()
        {
            return IsAdmin;
        }
    }
}
