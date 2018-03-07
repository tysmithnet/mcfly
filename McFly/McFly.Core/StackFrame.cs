// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 03-01-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="StackFrame.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core
{
    /// <summary>
    ///     Class StackFrame.
    /// </summary>
    public class StackFrame
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StackFrame" /> class.
        /// </summary>
        /// <param name="stackPointer">The stack pointer.</param>
        /// <param name="returnAddress">The return address.</param>
        /// <param name="module">The module.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="offset">The offset.</param>
        public StackFrame(ulong stackPointer, ulong returnAddress, string module, string functionName, uint offset)
        {
            StackPointer = stackPointer;
            ReturnAddress = returnAddress;
            Module = module;
            FunctionName = functionName;
            Offset = offset;
        }

        /// <summary>
        ///     Gets or sets the stack pointer.
        /// </summary>
        /// <value>The stack pointer.</value>
        public ulong StackPointer { get; set; }

        /// <summary>
        ///     Gets or sets the return address.
        /// </summary>
        /// <value>The return address.</value>
        public ulong ReturnAddress { get; set; }

        /// <summary>
        ///     Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public string Module { get; set; }

        /// <summary>
        ///     Gets or sets the name of the function.
        /// </summary>
        /// <value>The name of the function.</value>
        public string FunctionName { get; set; }

        /// <summary>
        ///     Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public uint Offset { get; set; }
    }
}