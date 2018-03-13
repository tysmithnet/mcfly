// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="Program.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Net.Http;
using McFly.Server.Data;
using Microsoft.Owin.Hosting;

namespace McFly.Server
{
    /// <summary>
    ///     Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            DataAccess.ConnectionString = //Environment.GetEnvironmentVariable("ConnectionString");
                "Data Source=localhost;Integrated Security=true";
            string baseAddress = "http://localhost:5000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }

        /// <summary>
        ///     Builds the web host.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IWebHost.</returns>
        //public static IWebHost BuildWebHost(string[] args)
        //{
            //return WebHost.CreateDefaultBuilder(args)
            //    .ConfigureAppConfiguration((context, builder) =>
            //    {
            //        var env = context.HostingEnvironment;
            //        builder.AddJsonFile("appsettings.json", true, true)
            //            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            //        builder.AddEnvironmentVariables();
            //    })
            //    .ConfigureLogging((context, builder) =>
            //    {
            //        builder.AddConsole();
            //        builder.AddDebug();
            //    })
            //    .UseStartup<Startup>()
            //    .Build();
        //}


    }
}