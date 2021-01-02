using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private readonly IJSRuntime jsRuntime;
        public HttpClient Http { get; set; }
    public UserDTO User { get; set; } = null;

    public event Action OnChange;
        public bool IsAdmin { get; set; } = false;
    public AuthenticationService(HttpClient http, IJSRuntime jsRuntime)
    {
      User = null;
      Http = http;
            this.jsRuntime = jsRuntime;
    }

        public async Task<bool> AuthenticateUser(string email, string password) {
      var response = await Http.PostAsJsonAsync<User>("api/users/authenticateUser", new User() { Email = email, Password =password });
      var body = await response.Content.ReadAsStringAsync();
      var authenticated = JsonConvert.DeserializeObject<bool>(body);
      if (authenticated) {
        User = await Http.GetFromJsonAsync<UserDTO>("api/users/email/" + email);
        User.IsAdmin = await Http.GetFromJsonAsync<bool>("api/users/" + User.UserId + "/isadmin");

                string serializedUser = System.Text.Json.JsonSerializer.Serialize(User);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedUser);
   

            }
            InvokeEvent();
      return User != null;
    }
    public async Task<bool> IsLoggedIn() {
            string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userAsJson))
            {
                User = System.Text.Json.JsonSerializer.Deserialize<UserDTO>(userAsJson);
            }
            return User != null;
    }
    public async Task LogOut() {
      User = null;
      IsAdmin = false;
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            
            InvokeEvent();
    }
        public UserDTO GetCurrentUser() { return User; }
    private void InvokeEvent() => OnChange?.Invoke();

        public async Task<bool> IsUserAdmin()
        {
            string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userAsJson))
            {
                User = System.Text.Json.JsonSerializer.Deserialize<UserDTO>(userAsJson);
            }
            return User != null && User.IsAdmin;
        }
    }
}
