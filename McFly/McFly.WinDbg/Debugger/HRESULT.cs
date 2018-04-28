// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="HRESULT.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Enum HRESULT
    /// </summary>
    public enum HRESULT : uint
    {
        /// <summary>
        ///     The s ok
        /// </summary>
        S_OK = 0,

        /// <summary>
        ///     The e abort
        /// </summary>
        E_ABORT = 4,

        /// <summary>
        ///     The e accessdenied
        /// </summary>
        E_ACCESSDENIED = 0x80070005,

        /// <summary>
        ///     The e fail
        /// </summary>
        E_FAIL = 0x80004005,

        /// <summary>
        ///     The e handle
        /// </summary>
        E_HANDLE = 0x80070006,

        /// <summary>
        ///     The e invalidarg
        /// </summary>
        E_INVALIDARG = 0x80070057,

        /// <summary>
        ///     The e nointerface
        /// </summary>
        E_NOINTERFACE = 0x80004002,

        /// <summary>
        ///     The e notimpl
        /// </summary>
        E_NOTIMPL = 0x80004001,

        /// <summary>
        ///     The e outofmemory
        /// </summary>
        E_OUTOFMEMORY = 0x8007000E,

        /// <summary>
        ///     The e pointer
        /// </summary>
        E_POINTER = 0x80004003,

        /// <summary>
        ///     The e unexpected
        /// </summary>
        E_UNEXPECTED = 0x8000FFFF
    }
}