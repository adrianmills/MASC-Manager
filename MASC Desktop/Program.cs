using Business_Logic.AutoMapProfiles;
using Business_Logic.DataRetrival;
using Business_Logic.DataRetrival.Interface;
using Masc_Model.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace MASC_Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            ApplicationConfiguration.Initialize();

            Application.Run(ServiceProvider.GetRequiredService<Parent>());
            //Application.Run(new Parent());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        { var conString = ConfigurationManager.ConnectionStrings["MascContext"].ConnectionString;
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddAutoMapper(typeof(MASCProfiles));
                    services.AddDbContext<MASCContext>(options => options.UseSqlServer(conString));
                    services.AddTransient<IClubData, ClubData>();
                    services.AddTransient<Clubs>();
                    services.AddTransient<Parent>();
                });
        }
    }
}