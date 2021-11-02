using RobotReservationService.Models;
using RobotReservationService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using RobotReservationService.Data;

namespace RobotReservationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRobotRepository, RobotRepository>();
            services.AddSingleton<IUserReferenceRepository, UserReferenceRepository>();
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.AddSingleton<IDBProvider, LiteDBProvider>();

            SetInitialData(services);
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        private static void SetInitialData(IServiceCollection services)
        {
            var roboRepo = services.BuildServiceProvider().GetService<IRobotRepository>();
            if (roboRepo.All().Any())
            {
                return;
            }
            roboRepo.Add(new Robot
            {
                Name = "Clarence",
                RobotType = "Cleaning",
                Description = "Cleaning Bot"
            });

            roboRepo.Add(new Robot
            {
                Name = "Randy",
                RobotType = "Removal",
                Description = "Removal Bot"
            });

            roboRepo.Add(new Robot
            {
                Name = "Barry",
                RobotType = "Bashing",
                Description = "Bashing Bot"
            });

            var userRepo = services.BuildServiceProvider().GetService<IUserReferenceRepository>();

            userRepo.Add(new UserReference
            {
                Username = "barryscott"
            });

            userRepo.Add(new UserReference
            {
                Username = "scottpilgrim"
            });

            var reservationRepo = services.BuildServiceProvider().GetService<IReservationRepository>();

            reservationRepo.Add(new Reservation
            {
                EndTime = System.DateTime.Now.AddDays(20),
                StartTime = System.DateTime.Now.AddDays(10),
                Username = "barryscott",
                Paid = false,
                RobotName = "Randy"
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc();
        }
    }
}
