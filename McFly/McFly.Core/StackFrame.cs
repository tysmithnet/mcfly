// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 03-01-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-09-2018
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

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool Equals(StackFrame other)
        {
            return StackPointer == other.StackPointer && ReturnAddress == other.ReturnAddress &&
                   string.Equals(Module, other.Module) && string.Equals(FunctionName, other.FunctionName) &&
                   Offset == other.Offset;
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
    }
}