using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using McFly.Server.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace McFly.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataAccess.ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var env = context.HostingEnvironment;
                    builder.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                    builder.AddEnvironmentVariables();
                })
                .ConfigureLogging((context, builder)=>
                {                             
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .UseStartup<Startup>()
                .Build();
    }
}
