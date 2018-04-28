// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="Program.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Common.Logging;
using Microsoft.Owin.Hosting;

namespace McFly.Server
{
    /// <summary>
    ///     Entry point into the application
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        ///     The log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
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