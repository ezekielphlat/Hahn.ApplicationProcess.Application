using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicationProcess.February2021.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO: set log file from appsettings
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("Logs\\outputlog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, loggin)=> {
                    loggin.ClearProviders();
                    loggin.AddFilter("Microsoft", LogLevel.Information);
                    loggin.AddFilter("System", LogLevel.Error);
                    loggin.AddDebug();
                    loggin.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
