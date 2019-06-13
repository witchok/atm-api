using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ATMBankDAL.Data.DataInitialization;
using ATMBankDAL.Data;

namespace ATMBankWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHostBuilder = CreateWebHostBuilder(args);
            var webHost = webHostBuilder.Build();
            using (var scope = webHost.Services.CreateScope())
            {
                ////Database initialization
                //var services = scope.ServiceProvider;
                //var context = services.GetRequiredService<ATMBankContext>();
                //MyDataInitializer.RecreateDatabase(context);
                //MyDataInitializer.InitializeData(context);
            }
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
