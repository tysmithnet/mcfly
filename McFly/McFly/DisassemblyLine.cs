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

namespace McFly
{
    /// <summary>
    ///     Class DisassemblyLine.
    /// </summary>
    internal class DisassemblyLine
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
            OpCodeMnemonic = opCodeMnemonic ?? throw new ArgumentNullException(nameof(opCodeMnemonic));
            DisassemblyNote = disassemblyNote ?? throw new ArgumentNullException(nameof(disassemblyNote));
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
    }
}