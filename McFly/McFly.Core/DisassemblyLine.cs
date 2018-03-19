// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-10-2018
//
// Last Modified By : master
// Last Modified On : 03-10-2018
// ***********************************************************************
// <copyright file="DisassemblyLine.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;

namespace McFly
{
    /// <summary>
    ///     Class DisassemblyLine.
    /// </summary>
    public class DisassemblyLine
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DisassemblyLine" /> class.
        /// </summary>
        /// <param name="instructionAddress">The instruction address.</param>
        /// <param name="opCode">The op code.</param>
        /// <param name="opCodeMnemonic">The op code mnemonic.</param>
        /// <param name="disassemblyNote">The disassembly note.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     opCode
        ///     or
        ///     opCodeMnemonic
        ///     or
        ///     disassemblyNote
        /// </exception>
        public DisassemblyLine(ulong instructionAddress, byte[] opCode, string opCodeMnemonic, string disassemblyNote)
        {
            InstructionAddress = instructionAddress;
            OpCode = opCode ?? throw new ArgumentNullException(nameof(opCode));
            OpCodeMnemonic = opCodeMnemonic?.Trim() ?? throw new ArgumentNullException(nameof(opCodeMnemonic));
            DisassemblyNote = disassemblyNote?.Trim() ?? throw new ArgumentNullException(nameof(disassemblyNote));
        }

        /// <summary>
        ///     Gets the instruction address.
        /// </summary>
        /// <value>The instruction address.</value>
        public ulong InstructionAddress { get; }

        /// <summary>
        ///     Gets the op code.
        /// </summary>
        /// <value>The op code.</value>
        public byte[] OpCode { get; }

        /// <summary>
        ///     Gets the op code mnemonic.
        /// </summary>
        /// <value>The op code mnemonic.</value>
        public string OpCodeMnemonic { get; }

        /// <summary>
        ///     Gets the disassembly note.
        /// </summary>
        /// <value>The disassembly note.</value>
        public string DisassemblyNote { get; }

        protected bool Equals(DisassemblyLine other)
        {
            bool inst = InstructionAddress == other.InstructionAddress;
            bool seq = OpCode.SequenceEqual(other.OpCode);
            bool mnem = OpCodeMnemonic == other.OpCodeMnemonic;
            bool note = DisassemblyNote == other.DisassemblyNote;
            return inst && seq && mnem && note;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DisassemblyLine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = InstructionAddress.GetHashCode();
                hashCode = (hashCode * 397) ^ (OpCode != null ? OpCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OpCodeMnemonic != null ? OpCodeMnemonic.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DisassemblyNote != null ? DisassemblyNote.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}