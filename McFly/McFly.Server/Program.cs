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
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opts =>
                {
                    DataAccess.ConnectionString = opts.ConnectionString ??
                                                  throw new ArgumentNullException("Connection string cannot be null");
                });
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
