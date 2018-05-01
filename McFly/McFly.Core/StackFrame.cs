// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="StackFrame.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core
{
    /// <summary>
    ///     Represents a single stack frame in a specific threads stack at a single instant in time during the trace
    /// </summary>
    public sealed class StackFrame
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StackFrame" /> class.
        /// </summary>
        /// <param name="stackPointer">The stack pointer.</param>
        /// <param name="returnAddress">The return address.</param>
        /// <param name="module">The module.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="offset">The offset.</param>
        public StackFrame(ulong stackPointer, ulong? returnAddress, string module, string functionName, ulong? offset)
        {
            StackPointer = stackPointer;
            ReturnAddress = returnAddress;
            Module = module;
            FunctionName = functionName;
            Offset = offset;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StackFrame) obj);
        }

        /// <summary>
        ///     Is this instance equal to another stack frame
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if both are equal, <c>false</c> otherwise.</returns>
        public bool Equals(StackFrame other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            var sp = StackPointer == other.StackPointer;
            if (!sp)
                return false;
            var ret = ReturnAddress == other.ReturnAddress;
            if (!ret)
                return false;
            var mod = string.Equals(Module, other.Module);
            if (!mod)
                return false;
            var fun = string.Equals(FunctionName, other.FunctionName);
            if (!fun)
                return false;
            var off = Offset == other.Offset;
            if (!off)
                return false;
            return true;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StackPointer.GetHashCode();
                hashCode = (hashCode * 397) ^ ReturnAddress.GetHashCode();
                hashCode = (hashCode * 397) ^ (Module != null ? Module.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FunctionName != null ? FunctionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Offset;
                return hashCode;
            }
        }

        /// <summary>
        ///     Gets or sets the name of the function.
        /// </summary>
        /// <value>The name of the function.</value>
        public string FunctionName { get; internal set; }

        /// <summary>
        ///     Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public string Module { get; internal set; }

        /// <summary>
        ///     Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public ulong? Offset { get; internal set; }

        /// <summary>
        ///     Gets or sets the return address.
        /// </summary>
        /// <value>The return address.</value>
        public ulong? ReturnAddress { get; internal set; }

        /// <summary>
        ///     Gets or sets the stack pointer.
        /// </summary>
        /// <value>The stack pointer.</value>
        public ulong StackPointer { get; internal set; }
    }
}