﻿// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-28-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="Frame.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace McFly.Core
{
    /// <summary>
    ///     Class Frame.
    /// </summary>
    public class Frame
    {
        private int _threadId;

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId
        {
            get => _threadId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be at least 0");
                _threadId = value;
            }
        }

        /// <summary>
        ///     Gets or sets the register set.
        /// </summary>
        /// <value>The register set.</value>
        public RegisterSet RegisterSet { get; set; }

        public StackTrace StackTrace { get; set; }

        public DisassemblyLine DisassemblyLine { get; set; }
    }
}