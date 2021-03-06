using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using MediatR;
using AutoMapper;
using TicketReservationSystem.Server.Context;
using Microsoft.EntityFrameworkCore;
using TicketReservationSystem.Server.Data.Repository.Abstraction;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Server.Data.Mapper;
using TicketReservationSystem.Shared.DTO;
using System.Text.Json.Serialization;
using TicketReservationSystem.Server.Services;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.OpenApi.Models;
using TicketReservationSystem.Server.Services.Security;

namespace TicketReservationSystem.Server
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

 
            services.AddSingleton(mapper);
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 10;
            });
            services.AddDataProtection();
            services.AddHangfire(c => c.UseMemoryStorage());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPaymentTimeoutService, PaymentTimeoutService>();
            services.AddRazorPages();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<MovieRepository>();
            services.AddTransient<HallRepository>();
            services.AddTransient<PaymentRepository>();
            services.AddTransient<ReservationRepository>();
            services.AddTransient<SeatReservationRepository>();
            services.AddTransient<SeatRepository>();
            services.AddTransient<ShowRepository>();
            services.AddTransient<CinemaRepository>();
            services.AddTransient<AdminRepository>();
            services.AddTransient<UserRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<MyContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
        }
    // This method gets called by the rutime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
      app.UseBlazorFrameworkFiles();
      app.UseStaticFiles();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new AllowAllDashboardAuthorizationFilter() }
            });

            app.UseRouting();
            app.UseDeveloperExceptionPage();
            app.UseHangfireServer();
            app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
        endpoints.MapControllers();
        endpoints.MapFallbackToFile("index.html");
      });
    }
  }
}
