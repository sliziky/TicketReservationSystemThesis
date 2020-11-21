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
      Http = http;
    }

    public HttpClient Http { get; set; }
    public UserDTO User { get; set; } = null;
    public async Task<bool> AuthenticateUser(string email, string password) {
      var response = await Http.PostAsJsonAsync<User>("api/users/authenticateUser", new User() { Email = email, Password =password });
      var body = await response.Content.ReadAsStringAsync();
      var authenticated = JsonConvert.DeserializeObject<bool>(body);
      if (authenticated) {
        User = await Http.GetFromJsonAsync<UserDTO>("api/users/" + email);
      }
      return User != null;
    }
    public void Logout() {
      User = null;
    }
  }
}
