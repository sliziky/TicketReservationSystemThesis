using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketReservationSystem.Client.Services;
using TicketReservationSystem.Client.Services.Abstraction;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection;

namespace TicketReservationSystem.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#appComponent");
      builder.Services
      .AddBlazorise(options =>
      {
        options.ChangeTextOnKeyPress = true;
      })
      .AddBootstrapProviders()
      .AddFontAwesomeIcons();
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
      };
      builder.Services.AddSingleton<HttpClient>(httpClient);
      builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
      await builder.Build().RunAsync();
    }
  }
}
