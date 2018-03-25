// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="Program.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using McFly.Server.Data;
using Microsoft.Owin.Hosting;

namespace McFly.Server
{
    /// <summary>
    ///     Class Program.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
            var baseAddress = "http://localhost:5000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                // Create HttpCient and make a request to api/values 

                Console.ReadLine();
            }
        }
    }
}