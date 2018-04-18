// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="Structs.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Struct IMAGEHLP_MODULE64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IMAGEHLP_MODULE64
    {
        /// <summary>
        ///     The maximum path
        /// </summary>
        private const int MAX_PATH = 260;

        /// <summary>
        ///     The size of structure
        /// </summary>
        public uint SizeOfStruct;

        /// <summary>
        ///     The base of image
        /// </summary>
        public ulong BaseOfImage;

        /// <summary>
        ///     The image size
        /// </summary>
        public uint ImageSize;

        /// <summary>
        ///     The time date stamp
        /// </summary>
        public uint TimeDateStamp;

        /// <summary>
        ///     The check sum
        /// </summary>
        public uint CheckSum;

        /// <summary>
        ///     The number syms
        /// </summary>
        public uint NumSyms;

        /// <summary>
        ///     The sym type
        /// </summary>
        public DEBUG_SYMTYPE SymType;

        /// <summary>
        ///     The module name
        /// </summary>
        private fixed char _ModuleName[32];

        /// <summary>
        ///     The image name
        /// </summary>
        private fixed char _ImageName[256];

        /// <summary>
        ///     The loaded image name
        /// </summary>
        private fixed char _LoadedImageName[256];

        /// <summary>
        ///     The loaded PDB name
        /// </summary>
        private fixed char _LoadedPdbName[256];

        /// <summary>
        ///     The cv sig
        /// </summary>
        public uint CVSig;

        /// <summary>
        ///     The cv data
        /// </summary>
        public fixed char CVData[MAX_PATH * 3];

        /// <summary>
        ///     The PDB sig
        /// </summary>
        public uint PdbSig;

        /// <summary>
        ///     The PDB sig70
        /// </summary>
        public Guid PdbSig70;

        /// <summary>
        ///     The PDB age
        /// </summary>
        public uint PdbAge;

        /// <summary>
        ///     The b PDB unmatched
        /// </summary>
        private uint _bPdbUnmatched; /* BOOL */

        /// <summary>
        ///     The b debug unmatched
        /// </summary>
        private uint _bDbgUnmatched; /* BOOL */

        /// <summary>
        ///     The b line numbers
        /// </summary>
        private uint _bLineNumbers; /* BOOL */

        /// <summary>
        ///     The b global symbols
        /// </summary>
        private uint _bGlobalSymbols; /* BOOL */

        /// <summary>
        ///     The b type information
        /// </summary>
        private uint _bTypeInfo; /* BOOL */

        /// <summary>
        ///     The b source indexed
        /// </summary>
        private uint _bSourceIndexed; /* BOOL */

        /// <summary>
        ///     The b publics
        /// </summary>
        private uint _bPublics; /* BOOL */

        /// <summary>
        ///     Gets or sets a value indicating whether [PDB unmatched].
        /// </summary>
        /// <value><c>true</c> if [PDB unmatched]; otherwise, <c>false</c>.</value>
        public bool PdbUnmatched
        {
            get => _bPdbUnmatched != 0;
            set => _bPdbUnmatched = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [debug unmatched].
        /// </summary>
        /// <value><c>true</c> if [debug unmatched]; otherwise, <c>false</c>.</value>
        public bool DbgUnmatched
        {
            get => _bDbgUnmatched != 0;
            set => _bDbgUnmatched = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [line numbers].
        /// </summary>
        /// <value><c>true</c> if [line numbers]; otherwise, <c>false</c>.</value>
        public bool LineNumbers
        {
            get => _bLineNumbers != 0;
            set => _bLineNumbers = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [global symbols].
        /// </summary>
        /// <value><c>true</c> if [global symbols]; otherwise, <c>false</c>.</value>
        public bool GlobalSymbols
        {
            get => _bGlobalSymbols != 0;
            set => _bGlobalSymbols = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [type information].
        /// </summary>
        /// <value><c>true</c> if [type information]; otherwise, <c>false</c>.</value>
        public bool TypeInfo
        {
            get => _bTypeInfo != 0;
            set => _bTypeInfo = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [source indexed].
        /// </summary>
        /// <value><c>true</c> if [source indexed]; otherwise, <c>false</c>.</value>
        public bool SourceIndexed
        {
            get => _bSourceIndexed != 0;
            set => _bSourceIndexed = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="IMAGEHLP_MODULE64" /> is publics.
        /// </summary>
        /// <value><c>true</c> if publics; otherwise, <c>false</c>.</value>
        public bool Publics
        {
            get => _bPublics != 0;
            set => _bPublics = value ? 1U : 0U;
        }

        /// <summary>
        ///     Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public string ModuleName
        {
            get
            {
                fixed (char* moduleNamePtr = _ModuleName)
                {
                    return Marshal.PtrToStringUni((IntPtr) moduleNamePtr, 32);
                }
            }
        }

        /// <summary>
        ///     Gets the name of the image.
        /// </summary>
        /// <value>The name of the image.</value>
        public string ImageName
        {
            get
            {
                fixed (char* imageNamePtr = _ImageName)
                {
                    return Marshal.PtrToStringUni((IntPtr) imageNamePtr, 256);
                }
            }
        }

        /// <summary>
        ///     Gets the name of the loaded image.
        /// </summary>
        /// <value>The name of the loaded image.</value>
        public string LoadedImageName
        {
            get
            {
                fixed (char* loadedImageNamePtr = _LoadedImageName)
                {
                    return Marshal.PtrToStringUni((IntPtr) loadedImageNamePtr, 256);
                }
            }
        }

        /// <summary>
        ///     Gets the name of the loaded PDB.
        /// </summary>
        /// <value>The name of the loaded PDB.</value>
        public string LoadedPdbName
        {
            get
            {
                fixed (char* loadedPdbNamePtr = _LoadedPdbName)
                {
                    return Marshal.PtrToStringUni((IntPtr) loadedPdbNamePtr, 256);
                }
            }
        }
    }

    /// <summary>
    ///     Struct DEBUG_THREAD_BASIC_INFORMATION
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_THREAD_BASIC_INFORMATION
    {
        /// <summary>
        ///     The valid
        /// </summary>
        public DEBUG_TBINFO Valid;

        /// <summary>
        ///     The exit status
        /// </summary>
        public uint ExitStatus;

        /// <summary>
        ///     The priority class
        /// </summary>
        public uint PriorityClass;

        /// <summary>
        ///     The priority
        /// </summary>
        public uint Priority;

        /// <summary>
        ///     The create time
        /// </summary>
        public ulong CreateTime;

        /// <summary>
        ///     The exit time
        /// </summary>
        public ulong ExitTime;

        /// <summary>
        ///     The kernel time
        /// </summary>
        public ulong KernelTime;

        /// <summary>
        ///     The user time
        /// </summary>
        public ulong UserTime;

        /// <summary>
        ///     The start offset
        /// </summary>
        public ulong StartOffset;

        /// <summary>
        ///     The affinity
        /// </summary>
        public ulong Affinity;
    }

    /// <summary>
    ///     Struct DEBUG_READ_USER_MINIDUMP_STREAM
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_READ_USER_MINIDUMP_STREAM
    {
        /// <summary>
        ///     The stream type
        /// </summary>
        public uint StreamType;

        /// <summary>
        ///     The flags
        /// </summary>
        public uint Flags;

        /// <summary>
        ///     The offset
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The buffer
        /// </summary>
        public IntPtr Buffer;

        /// <summary>
        ///     The buffer size
        /// </summary>
        public uint BufferSize;

        /// <summary>
        ///     The buffer used
        /// </summary>
        public uint BufferUsed;
    }

    /// <summary>
    ///     Struct DEBUG_GET_TEXT_COMPLETIONS_IN
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_GET_TEXT_COMPLETIONS_IN
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public DEBUG_GET_TEXT_COMPLETIONS Flags;

        /// <summary>
        ///     The match count limit
        /// </summary>
        public uint MatchCountLimit;

        /// <summary>
        ///     The reserved0
        /// </summary>
        public ulong Reserved0;

        /// <summary>
        ///     The reserved1
        /// </summary>
        public ulong Reserved1;

        /// <summary>
        ///     The reserved2
        /// </summary>
        public ulong Reserved2;
    }

    /// <summary>
    ///     Struct DEBUG_GET_TEXT_COMPLETIONS_OUT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_GET_TEXT_COMPLETIONS_OUT
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public DEBUG_GET_TEXT_COMPLETIONS Flags;

        /// <summary>
        ///     The replace index
        /// </summary>
        public uint ReplaceIndex;

        /// <summary>
        ///     The match count
        /// </summary>
        public uint MatchCount;

        /// <summary>
        ///     The reserved1
        /// </summary>
        public uint Reserved1;

        /// <summary>
        ///     The reserved2
        /// </summary>
        public ulong Reserved2;

        /// <summary>
        ///     The reserved3
        /// </summary>
        public ulong Reserved3;
    }

    /// <summary>
    ///     Struct DEBUG_CACHED_SYMBOL_INFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_CACHED_SYMBOL_INFO
    {
        /// <summary>
        ///     The mod base
        /// </summary>
        public ulong ModBase;

        /// <summary>
        ///     The arg1
        /// </summary>
        public ulong Arg1;

        /// <summary>
        ///     The arg2
        /// </summary>
        public ulong Arg2;

        /// <summary>
        ///     The identifier
        /// </summary>
        public uint Id;

        /// <summary>
        ///     The arg3
        /// </summary>
        public uint Arg3;
    }

    /// <summary>
    ///     Struct DEBUG_CREATE_PROCESS_OPTIONS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_CREATE_PROCESS_OPTIONS
    {
        /// <summary>
        ///     The create flags
        /// </summary>
        public DEBUG_CREATE_PROCESS CreateFlags;

        /// <summary>
        ///     The eng create flags
        /// </summary>
        public DEBUG_ECREATE_PROCESS EngCreateFlags;

        /// <summary>
        ///     The verifier flags
        /// </summary>
        public uint VerifierFlags;

        /// <summary>
        ///     The reserved
        /// </summary>
        public uint Reserved;
    }

    /// <summary>
    ///     Struct EXCEPTION_RECORD64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EXCEPTION_RECORD64
    {
        /// <summary>
        ///     The exception code
        /// </summary>
        public uint ExceptionCode;

        /// <summary>
        ///     The exception flags
        /// </summary>
        public uint ExceptionFlags;

        /// <summary>
        ///     The exception record
        /// </summary>
        public ulong ExceptionRecord;

        /// <summary>
        ///     The exception address
        /// </summary>
        public ulong ExceptionAddress;

        /// <summary>
        ///     The number parameters
        /// </summary>
        public uint NumberParameters;

        /// <summary>
        ///     The unused alignment
        /// </summary>
        public uint __unusedAlignment;

        /// <summary>
        ///     The exception information
        /// </summary>
        public fixed ulong ExceptionInformation[15]; //EXCEPTION_MAXIMUM_PARAMETERS
    }

    /// <summary>
    ///     Struct DEBUG_BREAKPOINT_PARAMETERS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_BREAKPOINT_PARAMETERS
    {
        /// <summary>
        ///     The offset
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The identifier
        /// </summary>
        public uint Id;

        /// <summary>
        ///     The break type
        /// </summary>
        public DEBUG_BREAKPOINT_TYPE BreakType;

        /// <summary>
        ///     The proc type
        /// </summary>
        public uint ProcType;

        /// <summary>
        ///     The flags
        /// </summary>
        public DEBUG_BREAKPOINT_FLAG Flags;

        /// <summary>
        ///     The data size
        /// </summary>
        public uint DataSize;

        /// <summary>
        ///     The data access type
        /// </summary>
        public DEBUG_BREAKPOINT_ACCESS_TYPE DataAccessType;

        /// <summary>
        ///     The pass count
        /// </summary>
        public uint PassCount;

        /// <summary>
        ///     The current pass count
        /// </summary>
        public uint CurrentPassCount;

        /// <summary>
        ///     The match thread
        /// </summary>
        public uint MatchThread;

        /// <summary>
        ///     The command size
        /// </summary>
        public uint CommandSize;

        /// <summary>
        ///     The offset expression size
        /// </summary>
        public uint OffsetExpressionSize;
    }

    /// <summary>
    ///     Struct DEBUG_REGISTER_DESCRIPTION
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_REGISTER_DESCRIPTION
    {
        /// <summary>
        ///     The type
        /// </summary>
        public DEBUG_VALUE_TYPE Type;

        /// <summary>
        ///     The flags
        /// </summary>
        public DEBUG_REGISTER Flags;

        /// <summary>
        ///     The subreg master
        /// </summary>
        public ulong SubregMaster;

        /// <summary>
        ///     The subreg length
        /// </summary>
        public ulong SubregLength;

        /// <summary>
        ///     The subreg mask
        /// </summary>
        public ulong SubregMask;

        /// <summary>
        ///     The subreg shift
        /// </summary>
        public ulong SubregShift;

        /// <summary>
        ///     The reserved0
        /// </summary>
        public ulong Reserved0;
    }

    /// <summary>
    ///     Struct I64PARTS32
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct I64PARTS32
    {
        /// <summary>
        ///     The low part
        /// </summary>
        [FieldOffset(0)] public uint LowPart;

        /// <summary>
        ///     The high part
        /// </summary>
        [FieldOffset(4)] public uint HighPart;
    }

    /// <summary>
    ///     Struct F128PARTS64
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct F128PARTS64
    {
        /// <summary>
        ///     The low part
        /// </summary>
        [FieldOffset(0)] public ulong LowPart;

        /// <summary>
        ///     The high part
        /// </summary>
        [FieldOffset(8)] public ulong HighPart;
    }

    /// <summary>
    ///     Struct DEBUG_VALUE
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct DEBUG_VALUE
    {
        /// <summary>
        ///     The i8
        /// </summary>
        [FieldOffset(0)] public byte I8;

        /// <summary>
        ///     The i16
        /// </summary>
        [FieldOffset(0)] public ushort I16;

        /// <summary>
        ///     The i32
        /// </summary>
        [FieldOffset(0)] public uint I32;

        /// <summary>
        ///     The i64
        /// </summary>
        [FieldOffset(0)] public ulong I64;

        /// <summary>
        ///     The nat
        /// </summary>
        [FieldOffset(8)] public uint Nat;

        /// <summary>
        ///     The F32
        /// </summary>
        [FieldOffset(0)] public float F32;

        /// <summary>
        ///     The F64
        /// </summary>
        [FieldOffset(0)] public double F64;

        /// <summary>
        ///     The F80 bytes
        /// </summary>
        [FieldOffset(0)] public fixed byte F80Bytes[10];

        /// <summary>
        ///     The F82 bytes
        /// </summary>
        [FieldOffset(0)] public fixed byte F82Bytes[11];

        /// <summary>
        ///     The F128 bytes
        /// </summary>
        [FieldOffset(0)] public fixed byte F128Bytes[16];

        /// <summary>
        ///     The v i8
        /// </summary>
        [FieldOffset(0)] public fixed byte VI8[16];

        /// <summary>
        ///     The v i16
        /// </summary>
        [FieldOffset(0)] public fixed ushort VI16[8];

        /// <summary>
        ///     The v i32
        /// </summary>
        [FieldOffset(0)] public fixed uint VI32[4];

        /// <summary>
        ///     The v i64
        /// </summary>
        [FieldOffset(0)] public fixed ulong VI64[2];

        /// <summary>
        ///     The v F32
        /// </summary>
        [FieldOffset(0)] public fixed float VF32[4];

        /// <summary>
        ///     The v F64
        /// </summary>
        [FieldOffset(0)] public fixed double VF64[2];

        /// <summary>
        ///     The i64 parts32
        /// </summary>
        [FieldOffset(0)] public I64PARTS32 I64Parts32;

        /// <summary>
        ///     The F128 parts64
        /// </summary>
        [FieldOffset(0)] public F128PARTS64 F128Parts64;

        /// <summary>
        ///     The raw bytes
        /// </summary>
        [FieldOffset(0)] public fixed byte RawBytes[24];

        /// <summary>
        ///     The tail of raw bytes
        /// </summary>
        [FieldOffset(24)] public uint TailOfRawBytes;

        /// <summary>
        ///     The type
        /// </summary>
        [FieldOffset(28)] public DEBUG_VALUE_TYPE Type;
    }

    /// <summary>
    ///     Struct DEBUG_MODULE_PARAMETERS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEBUG_MODULE_PARAMETERS
    {
        /// <summary>
        ///     The base
        /// </summary>
        public ulong Base;

        /// <summary>
        ///     The size
        /// </summary>
        public uint Size;

        /// <summary>
        ///     The time date stamp
        /// </summary>
        public uint TimeDateStamp;

        /// <summary>
        ///     The checksum
        /// </summary>
        public uint Checksum;

        /// <summary>
        ///     The flags
        /// </summary>
        public DEBUG_MODULE Flags;

        /// <summary>
        ///     The symbol type
        /// </summary>
        public DEBUG_SYMTYPE SymbolType;

        /// <summary>
        ///     The image name size
        /// </summary>
        public uint ImageNameSize;

        /// <summary>
        ///     The module name size
        /// </summary>
        public uint ModuleNameSize;

        /// <summary>
        ///     The loaded image name size
        /// </summary>
        public uint LoadedImageNameSize;

        /// <summary>
        ///     The symbol file name size
        /// </summary>
        public uint SymbolFileNameSize;

        /// <summary>
        ///     The mapped image name size
        /// </summary>
        public uint MappedImageNameSize;

        /// <summary>
        ///     The reserved
        /// </summary>
        public fixed ulong Reserved[2];
    }

    /// <summary>
    ///     Struct DEBUG_STACK_FRAME
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEBUG_STACK_FRAME
    {
        /// <summary>
        ///     The instruction offset
        /// </summary>
        public ulong InstructionOffset;

        /// <summary>
        ///     The return offset
        /// </summary>
        public ulong ReturnOffset;

        /// <summary>
        ///     The frame offset
        /// </summary>
        public ulong FrameOffset;

        /// <summary>
        ///     The stack offset
        /// </summary>
        public ulong StackOffset;

        /// <summary>
        ///     The function table entry
        /// </summary>
        public ulong FuncTableEntry;

        /// <summary>
        ///     The parameters
        /// </summary>
        public fixed ulong Params[4];

        /// <summary>
        ///     The reserved
        /// </summary>
        public fixed ulong Reserved[6];

        /// <summary>
        ///     The virtual
        /// </summary>
        public uint Virtual;

        /// <summary>
        ///     The frame number
        /// </summary>
        public uint FrameNumber;
    }

    /// <summary>
    ///     Struct DEBUG_STACK_FRAME_EX
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEBUG_STACK_FRAME_EX
    {
        /* DEBUG_STACK_FRAME */
        /// <summary>
        ///     The instruction offset
        /// </summary>
        public ulong InstructionOffset;

        /// <summary>
        ///     The return offset
        /// </summary>
        public ulong ReturnOffset;

        /// <summary>
        ///     The frame offset
        /// </summary>
        public ulong FrameOffset;

        /// <summary>
        ///     The stack offset
        /// </summary>
        public ulong StackOffset;

        /// <summary>
        ///     The function table entry
        /// </summary>
        public ulong FuncTableEntry;

        /// <summary>
        ///     The parameters
        /// </summary>
        public fixed ulong Params[4];

        /// <summary>
        ///     The reserved
        /// </summary>
        public fixed ulong Reserved[6];

        /// <summary>
        ///     The virtual
        /// </summary>
        public uint Virtual;

        /// <summary>
        ///     The frame number
        /// </summary>
        public uint FrameNumber;

        /* DEBUG_STACK_FRAME_EX */
        /// <summary>
        ///     The inline frame context
        /// </summary>
        public uint InlineFrameContext;

        /// <summary>
        ///     The reserved1
        /// </summary>
        public uint Reserved1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DEBUG_STACK_FRAME_EX" /> struct.
        /// </summary>
        /// <param name="dsf">The DSF.</param>
        public DEBUG_STACK_FRAME_EX(DEBUG_STACK_FRAME dsf)
        {
            InstructionOffset = dsf.InstructionOffset;
            ReturnOffset = dsf.ReturnOffset;
            FrameOffset = dsf.FrameOffset;
            StackOffset = dsf.StackOffset;
            FuncTableEntry = dsf.FuncTableEntry;
            fixed (ulong* pParams = Params)
            {
                for (var i = 0; i < 4; ++i)
                    pParams[i] = dsf.Params[i];
            }

            fixed (ulong* pReserved = Reserved)
            {
                for (var i = 0; i < 6; ++i)
                    pReserved[i] = dsf.Reserved[i];
            }

            Virtual = dsf.Virtual;
            FrameNumber = dsf.FrameNumber;
            InlineFrameContext = 0xFFFFFFFF;
            Reserved1 = 0;
        }
    }

    /// <summary>
    ///     Struct DEBUG_SYMBOL_PARAMETERS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_PARAMETERS
    {
        /// <summary>
        ///     The module
        /// </summary>
        public ulong Module;

        /// <summary>
        ///     The type identifier
        /// </summary>
        public uint TypeId;

        /// <summary>
        ///     The parent symbol
        /// </summary>
        public uint ParentSymbol;

        /// <summary>
        ///     The sub elements
        /// </summary>
        public uint SubElements;

        /// <summary>
        ///     The flags
        /// </summary>
        public DEBUG_SYMBOL Flags;

        /// <summary>
        ///     The reserved
        /// </summary>
        public ulong Reserved;
    }

    /// <summary>
    ///     Struct WINDBG_EXTENSION_APIS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDBG_EXTENSION_APIS /*32 or 64; both are defined the same in managed code*/
    {
        /// <summary>
        ///     The n size
        /// </summary>
        public uint nSize;

        /// <summary>
        ///     The lp output routine
        /// </summary>
        public IntPtr lpOutputRoutine;

        /// <summary>
        ///     The lp get expression routine
        /// </summary>
        public IntPtr lpGetExpressionRoutine;

        /// <summary>
        ///     The lp get symbol routine
        /// </summary>
        public IntPtr lpGetSymbolRoutine;

        /// <summary>
        ///     The lp disasm routine
        /// </summary>
        public IntPtr lpDisasmRoutine;

        /// <summary>
        ///     The lp check control c routine
        /// </summary>
        public IntPtr lpCheckControlCRoutine;

        /// <summary>
        ///     The lp read process memory routine
        /// </summary>
        public IntPtr lpReadProcessMemoryRoutine;

        /// <summary>
        ///     The lp write process memory routine
        /// </summary>
        public IntPtr lpWriteProcessMemoryRoutine;

        /// <summary>
        ///     The lp get thread context routine
        /// </summary>
        public IntPtr lpGetThreadContextRoutine;

        /// <summary>
        ///     The lp set thread context routine
        /// </summary>
        public IntPtr lpSetThreadContextRoutine;

        /// <summary>
        ///     The lp ioctl routine
        /// </summary>
        public IntPtr lpIoctlRoutine;

        /// <summary>
        ///     The lp stack trace routine
        /// </summary>
        public IntPtr lpStackTraceRoutine;
    }

    /// <summary>
    ///     Struct DEBUG_SPECIFIC_FILTER_PARAMETERS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SPECIFIC_FILTER_PARAMETERS
    {
        /// <summary>
        ///     The execution option
        /// </summary>
        public DEBUG_FILTER_EXEC_OPTION ExecutionOption;

        /// <summary>
        ///     The continue option
        /// </summary>
        public DEBUG_FILTER_CONTINUE_OPTION ContinueOption;

        /// <summary>
        ///     The text size
        /// </summary>
        public uint TextSize;

        /// <summary>
        ///     The command size
        /// </summary>
        public uint CommandSize;

        /// <summary>
        ///     The argument size
        /// </summary>
        public uint ArgumentSize;
    }

    /// <summary>
    ///     Struct DEBUG_EXCEPTION_FILTER_PARAMETERS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_EXCEPTION_FILTER_PARAMETERS
    {
        /// <summary>
        ///     The execution option
        /// </summary>
        public DEBUG_FILTER_EXEC_OPTION ExecutionOption;

        /// <summary>
        ///     The continue option
        /// </summary>
        public DEBUG_FILTER_CONTINUE_OPTION ContinueOption;

        /// <summary>
        ///     The text size
        /// </summary>
        public uint TextSize;

        /// <summary>
        ///     The command size
        /// </summary>
        public uint CommandSize;

        /// <summary>
        ///     The second command size
        /// </summary>
        public uint SecondCommandSize;

        /// <summary>
        ///     The exception code
        /// </summary>
        public uint ExceptionCode;
    }

    /// <summary>
    ///     Struct DEBUG_HANDLE_DATA_BASIC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_HANDLE_DATA_BASIC
    {
        /// <summary>
        ///     The type name size
        /// </summary>
        public uint TypeNameSize;

        /// <summary>
        ///     The object name size
        /// </summary>
        public uint ObjectNameSize;

        /// <summary>
        ///     The attributes
        /// </summary>
        public uint Attributes;

        /// <summary>
        ///     The granted access
        /// </summary>
        public uint GrantedAccess;

        /// <summary>
        ///     The handle count
        /// </summary>
        public uint HandleCount;

        /// <summary>
        ///     The pointer count
        /// </summary>
        public uint PointerCount;
    }

    /// <summary>
    ///     Struct MEMORY_BASIC_INFORMATION64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION64
    {
        /// <summary>
        ///     The base address
        /// </summary>
        public ulong BaseAddress;

        /// <summary>
        ///     The allocation base
        /// </summary>
        public ulong AllocationBase;

        /// <summary>
        ///     The allocation protect
        /// </summary>
        public PAGE AllocationProtect;

        /// <summary>
        ///     The alignment1
        /// </summary>
        public uint __alignment1;

        /// <summary>
        ///     The region size
        /// </summary>
        public ulong RegionSize;

        /// <summary>
        ///     The state
        /// </summary>
        public MEM State;

        /// <summary>
        ///     The protect
        /// </summary>
        public PAGE Protect;

        /// <summary>
        ///     The type
        /// </summary>
        public MEM Type;

        /// <summary>
        ///     The alignment2
        /// </summary>
        public uint __alignment2;
    }

    /// <summary>
    ///     Struct IMAGE_NT_HEADERS32
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_NT_HEADERS32
    {
        /// <summary>
        ///     The signature
        /// </summary>
        [FieldOffset(0)] public uint Signature;

        /// <summary>
        ///     The file header
        /// </summary>
        [FieldOffset(4)] public IMAGE_FILE_HEADER FileHeader;

        /// <summary>
        ///     The optional header
        /// </summary>
        [FieldOffset(24)] public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
    }

    /// <summary>
    ///     Struct IMAGE_NT_HEADERS64
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_NT_HEADERS64
    {
        /// <summary>
        ///     The signature
        /// </summary>
        [FieldOffset(0)] public uint Signature;

        /// <summary>
        ///     The file header
        /// </summary>
        [FieldOffset(4)] public IMAGE_FILE_HEADER FileHeader;

        /// <summary>
        ///     The optional header
        /// </summary>
        [FieldOffset(24)] public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
    }

    /// <summary>
    ///     Struct IMAGE_FILE_HEADER
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_FILE_HEADER
    {
        /// <summary>
        ///     The machine
        /// </summary>
        [FieldOffset(0)] public ushort Machine;

        /// <summary>
        ///     The number of sections
        /// </summary>
        [FieldOffset(2)] public ushort NumberOfSections;

        /// <summary>
        ///     The time date stamp
        /// </summary>
        [FieldOffset(4)] public uint TimeDateStamp;

        /// <summary>
        ///     The pointer to symbol table
        /// </summary>
        [FieldOffset(8)] public uint PointerToSymbolTable;

        /// <summary>
        ///     The number of symbols
        /// </summary>
        [FieldOffset(12)] public uint NumberOfSymbols;

        /// <summary>
        ///     The size of optional header
        /// </summary>
        [FieldOffset(16)] public ushort SizeOfOptionalHeader;

        /// <summary>
        ///     The characteristics
        /// </summary>
        [FieldOffset(18)] public ushort Characteristics;
    }

    /// <summary>
    ///     Struct IMAGE_DOS_HEADER
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IMAGE_DOS_HEADER
    {
        /// <summary>
        ///     The e magic
        /// </summary>
        [FieldOffset(0)] public ushort e_magic; // Magic number

        /// <summary>
        ///     The e CBLP
        /// </summary>
        [FieldOffset(2)] public ushort e_cblp; // Bytes on last page of file

        /// <summary>
        ///     The e cp
        /// </summary>
        [FieldOffset(4)] public ushort e_cp; // Pages in file

        /// <summary>
        ///     The e CRLC
        /// </summary>
        [FieldOffset(6)] public ushort e_crlc; // Relocations

        /// <summary>
        ///     The e cparhdr
        /// </summary>
        [FieldOffset(8)] public ushort e_cparhdr; // Size of header in paragraphs

        /// <summary>
        ///     The e minalloc
        /// </summary>
        [FieldOffset(10)] public ushort e_minalloc; // Minimum extra paragraphs needed

        /// <summary>
        ///     The e maxalloc
        /// </summary>
        [FieldOffset(12)] public ushort e_maxalloc; // Maximum extra paragraphs needed

        /// <summary>
        ///     The e ss
        /// </summary>
        [FieldOffset(14)] public ushort e_ss; // Initial (relative) SS value

        /// <summary>
        ///     The e sp
        /// </summary>
        [FieldOffset(16)] public ushort e_sp; // Initial SP value

        /// <summary>
        ///     The e csum
        /// </summary>
        [FieldOffset(18)] public ushort e_csum; // Checksum

        /// <summary>
        ///     The e ip
        /// </summary>
        [FieldOffset(20)] public ushort e_ip; // Initial IP value

        /// <summary>
        ///     The e cs
        /// </summary>
        [FieldOffset(22)] public ushort e_cs; // Initial (relative) CS value

        /// <summary>
        ///     The e lfarlc
        /// </summary>
        [FieldOffset(24)] public ushort e_lfarlc; // File address of relocation table

        /// <summary>
        ///     The e ovno
        /// </summary>
        [FieldOffset(26)] public ushort e_ovno; // Overlay number

        /// <summary>
        ///     The e resource
        /// </summary>
        [FieldOffset(28)] public fixed ushort e_res[4]; // Reserved words

        /// <summary>
        ///     The e oemid
        /// </summary>
        [FieldOffset(36)] public ushort e_oemid; // OEM identifier (for e_oeminfo)

        /// <summary>
        ///     The e oeminfo
        /// </summary>
        [FieldOffset(38)] public ushort e_oeminfo; // OEM information; e_oemid specific

        /// <summary>
        ///     The e res2
        /// </summary>
        [FieldOffset(40)] public fixed ushort e_res2[10]; // Reserved words

        /// <summary>
        ///     The e lfanew
        /// </summary>
        [FieldOffset(60)] public uint e_lfanew; // File address of new exe header
    }

    /// <summary>
    ///     Struct IMAGE_OPTIONAL_HEADER32
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_OPTIONAL_HEADER32
    {
        /// <summary>
        ///     The magic
        /// </summary>
        [FieldOffset(0)] public ushort Magic;

        /// <summary>
        ///     The major linker version
        /// </summary>
        [FieldOffset(2)] public byte MajorLinkerVersion;

        /// <summary>
        ///     The minor linker version
        /// </summary>
        [FieldOffset(3)] public byte MinorLinkerVersion;

        /// <summary>
        ///     The size of code
        /// </summary>
        [FieldOffset(4)] public uint SizeOfCode;

        /// <summary>
        ///     The size of initialized data
        /// </summary>
        [FieldOffset(8)] public uint SizeOfInitializedData;

        /// <summary>
        ///     The size of uninitialized data
        /// </summary>
        [FieldOffset(12)] public uint SizeOfUninitializedData;

        /// <summary>
        ///     The address of entry point
        /// </summary>
        [FieldOffset(16)] public uint AddressOfEntryPoint;

        /// <summary>
        ///     The base of code
        /// </summary>
        [FieldOffset(20)] public uint BaseOfCode;

        /// <summary>
        ///     The base of data
        /// </summary>
        [FieldOffset(24)] public uint BaseOfData;

        /// <summary>
        ///     The image base
        /// </summary>
        [FieldOffset(28)] public uint ImageBase;

        /// <summary>
        ///     The section alignment
        /// </summary>
        [FieldOffset(32)] public uint SectionAlignment;

        /// <summary>
        ///     The file alignment
        /// </summary>
        [FieldOffset(36)] public uint FileAlignment;

        /// <summary>
        ///     The major operating system version
        /// </summary>
        [FieldOffset(40)] public ushort MajorOperatingSystemVersion;

        /// <summary>
        ///     The minor operating system version
        /// </summary>
        [FieldOffset(42)] public ushort MinorOperatingSystemVersion;

        /// <summary>
        ///     The major image version
        /// </summary>
        [FieldOffset(44)] public ushort MajorImageVersion;

        /// <summary>
        ///     The minor image version
        /// </summary>
        [FieldOffset(46)] public ushort MinorImageVersion;

        /// <summary>
        ///     The major subsystem version
        /// </summary>
        [FieldOffset(48)] public ushort MajorSubsystemVersion;

        /// <summary>
        ///     The minor subsystem version
        /// </summary>
        [FieldOffset(50)] public ushort MinorSubsystemVersion;

        /// <summary>
        ///     The win32 version value
        /// </summary>
        [FieldOffset(52)] public uint Win32VersionValue;

        /// <summary>
        ///     The size of image
        /// </summary>
        [FieldOffset(56)] public uint SizeOfImage;

        /// <summary>
        ///     The size of headers
        /// </summary>
        [FieldOffset(60)] public uint SizeOfHeaders;

        /// <summary>
        ///     The check sum
        /// </summary>
        [FieldOffset(64)] public uint CheckSum;

        /// <summary>
        ///     The subsystem
        /// </summary>
        [FieldOffset(68)] public ushort Subsystem;

        /// <summary>
        ///     The DLL characteristics
        /// </summary>
        [FieldOffset(70)] public ushort DllCharacteristics;

        /// <summary>
        ///     The size of stack reserve
        /// </summary>
        [FieldOffset(72)] public uint SizeOfStackReserve;

        /// <summary>
        ///     The size of stack commit
        /// </summary>
        [FieldOffset(76)] public uint SizeOfStackCommit;

        /// <summary>
        ///     The size of heap reserve
        /// </summary>
        [FieldOffset(80)] public uint SizeOfHeapReserve;

        /// <summary>
        ///     The size of heap commit
        /// </summary>
        [FieldOffset(84)] public uint SizeOfHeapCommit;

        /// <summary>
        ///     The loader flags
        /// </summary>
        [FieldOffset(88)] public uint LoaderFlags;

        /// <summary>
        ///     The number of rva and sizes
        /// </summary>
        [FieldOffset(92)] public uint NumberOfRvaAndSizes;

        /// <summary>
        ///     The data directory0
        /// </summary>
        [FieldOffset(96)] public IMAGE_DATA_DIRECTORY DataDirectory0;

        /// <summary>
        ///     The data directory1
        /// </summary>
        [FieldOffset(104)] public IMAGE_DATA_DIRECTORY DataDirectory1;

        /// <summary>
        ///     The data directory2
        /// </summary>
        [FieldOffset(112)] public IMAGE_DATA_DIRECTORY DataDirectory2;

        /// <summary>
        ///     The data directory3
        /// </summary>
        [FieldOffset(120)] public IMAGE_DATA_DIRECTORY DataDirectory3;

        /// <summary>
        ///     The data directory4
        /// </summary>
        [FieldOffset(128)] public IMAGE_DATA_DIRECTORY DataDirectory4;

        /// <summary>
        ///     The data directory5
        /// </summary>
        [FieldOffset(136)] public IMAGE_DATA_DIRECTORY DataDirectory5;

        /// <summary>
        ///     The data directory6
        /// </summary>
        [FieldOffset(144)] public IMAGE_DATA_DIRECTORY DataDirectory6;

        /// <summary>
        ///     The data directory7
        /// </summary>
        [FieldOffset(152)] public IMAGE_DATA_DIRECTORY DataDirectory7;

        /// <summary>
        ///     The data directory8
        /// </summary>
        [FieldOffset(160)] public IMAGE_DATA_DIRECTORY DataDirectory8;

        /// <summary>
        ///     The data directory9
        /// </summary>
        [FieldOffset(168)] public IMAGE_DATA_DIRECTORY DataDirectory9;

        /// <summary>
        ///     The data directory10
        /// </summary>
        [FieldOffset(176)] public IMAGE_DATA_DIRECTORY DataDirectory10;

        /// <summary>
        ///     The data directory11
        /// </summary>
        [FieldOffset(284)] public IMAGE_DATA_DIRECTORY DataDirectory11;

        /// <summary>
        ///     The data directory12
        /// </summary>
        [FieldOffset(292)] public IMAGE_DATA_DIRECTORY DataDirectory12;

        /// <summary>
        ///     The data directory13
        /// </summary>
        [FieldOffset(300)] public IMAGE_DATA_DIRECTORY DataDirectory13;

        /// <summary>
        ///     The data directory14
        /// </summary>
        [FieldOffset(308)] public IMAGE_DATA_DIRECTORY DataDirectory14;

        /// <summary>
        ///     The data directory15
        /// </summary>
        [FieldOffset(316)] public IMAGE_DATA_DIRECTORY DataDirectory15;

        /// <summary>
        ///     Gets the data directory.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="zeroBasedIndex">Index of the zero based.</param>
        /// <returns>IMAGE_DATA_DIRECTORY.</returns>
        public static unsafe IMAGE_DATA_DIRECTORY* GetDataDirectory(IMAGE_OPTIONAL_HEADER32* header, int zeroBasedIndex)
        {
            return &header->DataDirectory0 + zeroBasedIndex;
        }
    }

    /// <summary>
    ///     Struct IMAGE_OPTIONAL_HEADER64
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_OPTIONAL_HEADER64
    {
        /// <summary>
        ///     The magic
        /// </summary>
        [FieldOffset(0)] public ushort Magic;

        /// <summary>
        ///     The major linker version
        /// </summary>
        [FieldOffset(2)] public byte MajorLinkerVersion;

        /// <summary>
        ///     The minor linker version
        /// </summary>
        [FieldOffset(3)] public byte MinorLinkerVersion;

        /// <summary>
        ///     The size of code
        /// </summary>
        [FieldOffset(4)] public uint SizeOfCode;

        /// <summary>
        ///     The size of initialized data
        /// </summary>
        [FieldOffset(8)] public uint SizeOfInitializedData;

        /// <summary>
        ///     The size of uninitialized data
        /// </summary>
        [FieldOffset(12)] public uint SizeOfUninitializedData;

        /// <summary>
        ///     The address of entry point
        /// </summary>
        [FieldOffset(16)] public uint AddressOfEntryPoint;

        /// <summary>
        ///     The base of code
        /// </summary>
        [FieldOffset(20)] public uint BaseOfCode;

        /// <summary>
        ///     The image base
        /// </summary>
        [FieldOffset(24)] public ulong ImageBase;

        /// <summary>
        ///     The section alignment
        /// </summary>
        [FieldOffset(32)] public uint SectionAlignment;

        /// <summary>
        ///     The file alignment
        /// </summary>
        [FieldOffset(36)] public uint FileAlignment;

        /// <summary>
        ///     The major operating system version
        /// </summary>
        [FieldOffset(40)] public ushort MajorOperatingSystemVersion;

        /// <summary>
        ///     The minor operating system version
        /// </summary>
        [FieldOffset(42)] public ushort MinorOperatingSystemVersion;

        /// <summary>
        ///     The major image version
        /// </summary>
        [FieldOffset(44)] public ushort MajorImageVersion;

        /// <summary>
        ///     The minor image version
        /// </summary>
        [FieldOffset(46)] public ushort MinorImageVersion;

        /// <summary>
        ///     The major subsystem version
        /// </summary>
        [FieldOffset(48)] public ushort MajorSubsystemVersion;

        /// <summary>
        ///     The minor subsystem version
        /// </summary>
        [FieldOffset(50)] public ushort MinorSubsystemVersion;

        /// <summary>
        ///     The win32 version value
        /// </summary>
        [FieldOffset(52)] public uint Win32VersionValue;

        /// <summary>
        ///     The size of image
        /// </summary>
        [FieldOffset(56)] public uint SizeOfImage;

        /// <summary>
        ///     The size of headers
        /// </summary>
        [FieldOffset(60)] public uint SizeOfHeaders;

        /// <summary>
        ///     The check sum
        /// </summary>
        [FieldOffset(64)] public uint CheckSum;

        /// <summary>
        ///     The subsystem
        /// </summary>
        [FieldOffset(68)] public ushort Subsystem;

        /// <summary>
        ///     The DLL characteristics
        /// </summary>
        [FieldOffset(70)] public ushort DllCharacteristics;

        /// <summary>
        ///     The size of stack reserve
        /// </summary>
        [FieldOffset(72)] public ulong SizeOfStackReserve;

        /// <summary>
        ///     The size of stack commit
        /// </summary>
        [FieldOffset(80)] public ulong SizeOfStackCommit;

        /// <summary>
        ///     The size of heap reserve
        /// </summary>
        [FieldOffset(88)] public ulong SizeOfHeapReserve;

        /// <summary>
        ///     The size of heap commit
        /// </summary>
        [FieldOffset(96)] public ulong SizeOfHeapCommit;

        /// <summary>
        ///     The loader flags
        /// </summary>
        [FieldOffset(104)] public uint LoaderFlags;

        /// <summary>
        ///     The number of rva and sizes
        /// </summary>
        [FieldOffset(108)] public uint NumberOfRvaAndSizes;

        /// <summary>
        ///     The data directory0
        /// </summary>
        [FieldOffset(112)] public IMAGE_DATA_DIRECTORY DataDirectory0;

        /// <summary>
        ///     The data directory1
        /// </summary>
        [FieldOffset(120)] public IMAGE_DATA_DIRECTORY DataDirectory1;

        /// <summary>
        ///     The data directory2
        /// </summary>
        [FieldOffset(128)] public IMAGE_DATA_DIRECTORY DataDirectory2;

        /// <summary>
        ///     The data directory3
        /// </summary>
        [FieldOffset(136)] public IMAGE_DATA_DIRECTORY DataDirectory3;

        /// <summary>
        ///     The data directory4
        /// </summary>
        [FieldOffset(144)] public IMAGE_DATA_DIRECTORY DataDirectory4;

        /// <summary>
        ///     The data directory5
        /// </summary>
        [FieldOffset(152)] public IMAGE_DATA_DIRECTORY DataDirectory5;

        /// <summary>
        ///     The data directory6
        /// </summary>
        [FieldOffset(160)] public IMAGE_DATA_DIRECTORY DataDirectory6;

        /// <summary>
        ///     The data directory7
        /// </summary>
        [FieldOffset(168)] public IMAGE_DATA_DIRECTORY DataDirectory7;

        /// <summary>
        ///     The data directory8
        /// </summary>
        [FieldOffset(176)] public IMAGE_DATA_DIRECTORY DataDirectory8;

        /// <summary>
        ///     The data directory9
        /// </summary>
        [FieldOffset(184)] public IMAGE_DATA_DIRECTORY DataDirectory9;

        /// <summary>
        ///     The data directory10
        /// </summary>
        [FieldOffset(192)] public IMAGE_DATA_DIRECTORY DataDirectory10;

        /// <summary>
        ///     The data directory11
        /// </summary>
        [FieldOffset(200)] public IMAGE_DATA_DIRECTORY DataDirectory11;

        /// <summary>
        ///     The data directory12
        /// </summary>
        [FieldOffset(208)] public IMAGE_DATA_DIRECTORY DataDirectory12;

        /// <summary>
        ///     The data directory13
        /// </summary>
        [FieldOffset(216)] public IMAGE_DATA_DIRECTORY DataDirectory13;

        /// <summary>
        ///     The data directory14
        /// </summary>
        [FieldOffset(224)] public IMAGE_DATA_DIRECTORY DataDirectory14;

        /// <summary>
        ///     The data directory15
        /// </summary>
        [FieldOffset(232)] public IMAGE_DATA_DIRECTORY DataDirectory15;

        /// <summary>
        ///     Gets the data directory.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="zeroBasedIndex">Index of the zero based.</param>
        /// <returns>IMAGE_DATA_DIRECTORY.</returns>
        public static unsafe IMAGE_DATA_DIRECTORY* GetDataDirectory(IMAGE_OPTIONAL_HEADER64* header, int zeroBasedIndex)
        {
            return &header->DataDirectory0 + zeroBasedIndex;
        }
    }

    /// <summary>
    ///     Struct IMAGE_DATA_DIRECTORY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_DATA_DIRECTORY
    {
        /// <summary>
        ///     The virtual address
        /// </summary>
        public uint VirtualAddress;

        /// <summary>
        ///     The size
        /// </summary>
        public uint Size;
    }

    /// <summary>
    ///     Describes a symbol within a module.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_MODULE_AND_ID
    {
        /// <summary>
        ///     The location in the target's virtual address space of the module's base address.
        /// </summary>
        public ulong ModuleBase;

        /// <summary>
        ///     The symbol ID of the symbol within the module.
        /// </summary>
        public ulong Id;
    }

    /// <summary>
    ///     Struct DEBUG_SYMBOL_ENTRY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_ENTRY
    {
        /// <summary>
        ///     The module base
        /// </summary>
        public ulong ModuleBase;

        /// <summary>
        ///     The offset
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The identifier
        /// </summary>
        public ulong Id;

        /// <summary>
        ///     The arg64
        /// </summary>
        public ulong Arg64;

        /// <summary>
        ///     The size
        /// </summary>
        public uint Size;

        /// <summary>
        ///     The flags
        /// </summary>
        public uint Flags;

        /// <summary>
        ///     The type identifier
        /// </summary>
        public uint TypeId;

        /// <summary>
        ///     The name size
        /// </summary>
        public uint NameSize;

        /// <summary>
        ///     The token
        /// </summary>
        public uint Token;

        /// <summary>
        ///     The tag
        /// </summary>
        public SymTag Tag;

        /// <summary>
        ///     The arg32
        /// </summary>
        public uint Arg32;

        /// <summary>
        ///     The reserved
        /// </summary>
        public uint Reserved;
    }

    /// <summary>
    ///     Struct IMAGE_IMPORT_DESCRIPTOR
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_IMPORT_DESCRIPTOR
    {
        /// <summary>
        ///     The characteristics
        /// </summary>
        [FieldOffset(0)] public uint Characteristics; // 0 for terminating null import descriptor

        /// <summary>
        ///     The original first thunk
        /// </summary>
        [FieldOffset(0)] public uint OriginalFirstThunk; // RVA to original unbound IAT (PIMAGE_THUNK_DATA)

        /// <summary>
        ///     The time date stamp
        /// </summary>
        [FieldOffset(4)] public uint TimeDateStamp; // 0 if not bound,
        // -1 if bound, and real date\time stamp
        //     in IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT (new BIND)
        // O.W. date/time stamp of DLL bound to (Old BIND)

        /// <summary>
        ///     The forwarder chain
        /// </summary>
        [FieldOffset(8)] public uint ForwarderChain; // -1 if no forwarders

        /// <summary>
        ///     The name
        /// </summary>
        [FieldOffset(12)] public uint Name;

        /// <summary>
        ///     The first thunk
        /// </summary>
        [FieldOffset(16)] public uint FirstThunk; // RVA to IAT (if bound this IAT has actual addresses)
    }

    /// <summary>
    ///     Struct IMAGE_THUNK_DATA32
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_THUNK_DATA32
    {
        /// <summary>
        ///     The forwarder string
        /// </summary>
        [FieldOffset(0)] public uint ForwarderString; // PBYTE

        /// <summary>
        ///     The function
        /// </summary>
        [FieldOffset(0)] public uint Function; // PDWORD

        /// <summary>
        ///     The ordinal
        /// </summary>
        [FieldOffset(0)] public uint Ordinal;

        /// <summary>
        ///     The address of data
        /// </summary>
        [FieldOffset(0)] public uint AddressOfData; // PIMAGE_IMPORT_BY_NAME
    }

    /// <summary>
    ///     Struct IMAGE_THUNK_DATA64
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_THUNK_DATA64
    {
        /// <summary>
        ///     The forwarder string
        /// </summary>
        [FieldOffset(0)] public ulong ForwarderString; // PBYTE

        /// <summary>
        ///     The function
        /// </summary>
        [FieldOffset(0)] public ulong Function; // PDWORD

        /// <summary>
        ///     The ordinal
        /// </summary>
        [FieldOffset(0)] public ulong Ordinal;

        /// <summary>
        ///     The address of data
        /// </summary>
        [FieldOffset(0)] public ulong AddressOfData; // PIMAGE_IMPORT_BY_NAME
    }

    /// <summary>
    ///     Struct LANGANDCODEPAGE
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct LANGANDCODEPAGE
    {
        /// <summary>
        ///     The w language
        /// </summary>
        [FieldOffset(0)] public ushort wLanguage;

        /// <summary>
        ///     The w code page
        /// </summary>
        [FieldOffset(2)] public ushort wCodePage;
    }

    /// <summary>
    ///     Struct VS_FIXEDFILEINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VS_FIXEDFILEINFO
    {
        /// <summary>
        ///     The dw signature
        /// </summary>
        public uint dwSignature;

        /// <summary>
        ///     The dw struc version
        /// </summary>
        public uint dwStrucVersion;

        /// <summary>
        ///     The dw file version ms
        /// </summary>
        public uint dwFileVersionMS;

        /// <summary>
        ///     The dw file version ls
        /// </summary>
        public uint dwFileVersionLS;

        /// <summary>
        ///     The dw product version ms
        /// </summary>
        public uint dwProductVersionMS;

        /// <summary>
        ///     The dw product version ls
        /// </summary>
        public uint dwProductVersionLS;

        /// <summary>
        ///     The dw file flags mask
        /// </summary>
        public uint dwFileFlagsMask;

        /// <summary>
        ///     The dw file flags
        /// </summary>
        public VS_FF dwFileFlags;

        /// <summary>
        ///     The dw file os
        /// </summary>
        public uint dwFileOS;

        /// <summary>
        ///     The dw file type
        /// </summary>
        public uint dwFileType;

        /// <summary>
        ///     The dw file subtype
        /// </summary>
        public uint dwFileSubtype;

        /// <summary>
        ///     The dw file date ms
        /// </summary>
        public uint dwFileDateMS;

        /// <summary>
        ///     The dw file date ls
        /// </summary>
        public uint dwFileDateLS;
    }

    /// <summary>
    ///     Struct IMAGE_COR20_HEADER_ENTRYPOINT
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_COR20_HEADER_ENTRYPOINT
    {
        /// <summary>
        ///     The token
        /// </summary>
        [FieldOffset(0)] private readonly uint _token;

        /// <summary>
        ///     The rva
        /// </summary>
        [FieldOffset(0)] private readonly uint _RVA;
    }

    /// <summary>
    ///     Struct IMAGE_COR20_HEADER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_COR20_HEADER
    {
        // Header versioning
        /// <summary>
        ///     The cb
        /// </summary>
        public uint cb;

        /// <summary>
        ///     The major runtime version
        /// </summary>
        public ushort MajorRuntimeVersion;

        /// <summary>
        ///     The minor runtime version
        /// </summary>
        public ushort MinorRuntimeVersion;

        // Symbol table and startup information
        /// <summary>
        ///     The meta data
        /// </summary>
        public IMAGE_DATA_DIRECTORY MetaData;

        /// <summary>
        ///     The flags
        /// </summary>
        public uint Flags;

        // The main program if it is an EXE (not used if a DLL?)
        // If COMIMAGE_FLAGS_NATIVE_ENTRYPOINT is not set, EntryPointToken represents a managed entrypoint.
        // If COMIMAGE_FLAGS_NATIVE_ENTRYPOINT is set, EntryPointRVA represents an RVA to a native entrypoint
        // (depricated for DLLs, use modules constructors intead).
        /// <summary>
        ///     The entry point
        /// </summary>
        public IMAGE_COR20_HEADER_ENTRYPOINT EntryPoint;

        // This is the blob of managed resources. Fetched using code:AssemblyNative.GetResource and
        // code:PEFile.GetResource and accessible from managed code from
        // System.Assembly.GetManifestResourceStream.  The meta data has a table that maps names to offsets into
        // this blob, so logically the blob is a set of resources.
        /// <summary>
        ///     The resources
        /// </summary>
        public IMAGE_DATA_DIRECTORY Resources;

        // IL assemblies can be signed with a public-private key to validate who created it.  The signature goes
        // here if this feature is used.
        /// <summary>
        ///     The strong name signature
        /// </summary>
        public IMAGE_DATA_DIRECTORY StrongNameSignature;

        /// <summary>
        ///     The code manager table
        /// </summary>
        public IMAGE_DATA_DIRECTORY CodeManagerTable; // Depricated, not used

        // Used for manged codee that has unmaanaged code inside it (or exports methods as unmanaged entry points)
        /// <summary>
        ///     The v table fixups
        /// </summary>
        public IMAGE_DATA_DIRECTORY VTableFixups;

        /// <summary>
        ///     The export address table jumps
        /// </summary>
        public IMAGE_DATA_DIRECTORY ExportAddressTableJumps;

        // null for ordinary IL images.  NGEN images it points at a code:CORCOMPILE_HEADER structure
        /// <summary>
        ///     The managed native header
        /// </summary>
        public IMAGE_DATA_DIRECTORY ManagedNativeHeader;
    }

    /// <summary>
    ///     Struct WDBGEXTS_THREAD_OS_INFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WDBGEXTS_THREAD_OS_INFO
    {
        /// <summary>
        ///     The thread identifier
        /// </summary>
        public uint ThreadId;

        /// <summary>
        ///     The exit status
        /// </summary>
        public uint ExitStatus;

        /// <summary>
        ///     The priority class
        /// </summary>
        public uint PriorityClass;

        /// <summary>
        ///     The priority
        /// </summary>
        public uint Priority;

        /// <summary>
        ///     The create time
        /// </summary>
        public ulong CreateTime;

        /// <summary>
        ///     The exit time
        /// </summary>
        public ulong ExitTime;

        /// <summary>
        ///     The kernel time
        /// </summary>
        public ulong KernelTime;

        /// <summary>
        ///     The user time
        /// </summary>
        public ulong UserTime;

        /// <summary>
        ///     The start offset
        /// </summary>
        public ulong StartOffset;

        /// <summary>
        ///     The affinity
        /// </summary>
        public ulong Affinity;
    }

    /// <summary>
    ///     Struct WDBGEXTS_CLR_DATA_INTERFACE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WDBGEXTS_CLR_DATA_INTERFACE
    {
        /// <summary>
        ///     The iid
        /// </summary>
        public Guid* Iid;

        /// <summary>
        ///     The iface
        /// </summary>
        private readonly void* _iface;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WDBGEXTS_CLR_DATA_INTERFACE" /> struct.
        /// </summary>
        /// <param name="iid">The iid.</param>
        public WDBGEXTS_CLR_DATA_INTERFACE(Guid* iid)
        {
            Iid = iid;
            _iface = null;
        }

        /// <summary>
        ///     Gets the interface.
        /// </summary>
        /// <value>The interface.</value>
        public object Interface => _iface != null ? Marshal.GetObjectForIUnknown((IntPtr) _iface) : null;
    }

    /// <summary>
    ///     Struct DEBUG_SYMBOL_SOURCE_ENTRY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_SOURCE_ENTRY
    {
        /// <summary>
        ///     The module base
        /// </summary>
        private readonly ulong _moduleBase;

        /// <summary>
        ///     The offset
        /// </summary>
        private readonly ulong _offset;

        /// <summary>
        ///     The file name identifier
        /// </summary>
        private readonly ulong _fileNameId;

        /// <summary>
        ///     The engine internal
        /// </summary>
        private readonly ulong _engineInternal;

        /// <summary>
        ///     The size
        /// </summary>
        private readonly uint _size;

        /// <summary>
        ///     The flags
        /// </summary>
        private readonly uint _flags;

        /// <summary>
        ///     The file name size
        /// </summary>
        private readonly uint _fileNameSize;

        // Line numbers are one-based.
        // May be DEBUG_ANY_ID if unknown.
        /// <summary>
        ///     The start line
        /// </summary>
        private readonly uint _startLine;

        /// <summary>
        ///     The end line
        /// </summary>
        private readonly uint _endLine;

        // Column numbers are one-based byte indices.
        // May be DEBUG_ANY_ID if unknown.
        /// <summary>
        ///     The start column
        /// </summary>
        private readonly uint _startColumn;

        /// <summary>
        ///     The end column
        /// </summary>
        private readonly uint _endColumn;

        /// <summary>
        ///     The reserved
        /// </summary>
        private readonly uint _reserved;
    }

    /// <summary>
    ///     Struct DEBUG_OFFSET_REGION
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_OFFSET_REGION
    {
        /// <summary>
        ///     The base
        /// </summary>
        private readonly ulong _base;

        /// <summary>
        ///     The size
        /// </summary>
        private readonly ulong _size;
    }

    /// <summary>
    ///     Struct _DEBUG_TYPED_DATA
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct _DEBUG_TYPED_DATA
    {
        /// <summary>
        ///     The mod base
        /// </summary>
        public ulong ModBase;

        /// <summary>
        ///     The offset
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The engine handle
        /// </summary>
        public ulong EngineHandle;

        /// <summary>
        ///     The data
        /// </summary>
        public ulong Data;

        /// <summary>
        ///     The size
        /// </summary>
        public uint Size;

        /// <summary>
        ///     The flags
        /// </summary>
        public uint Flags;

        /// <summary>
        ///     The type identifier
        /// </summary>
        public uint TypeId;

        /// <summary>
        ///     The base type identifier
        /// </summary>
        public uint BaseTypeId;

        /// <summary>
        ///     The tag
        /// </summary>
        public uint Tag;

        /// <summary>
        ///     The register
        /// </summary>
        public uint Register;

        /// <summary>
        ///     The internal
        /// </summary>
        public fixed ulong Internal[9];
    }

    /// <summary>
    ///     Struct _EXT_TYPED_DATA
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct _EXT_TYPED_DATA
    {
        /// <summary>
        ///     The operation
        /// </summary>
        public _EXT_TDOP Operation;

        /// <summary>
        ///     The flags
        /// </summary>
        public uint Flags;

        /// <summary>
        ///     The in data
        /// </summary>
        public _DEBUG_TYPED_DATA InData;

        /// <summary>
        ///     The out data
        /// </summary>
        public _DEBUG_TYPED_DATA OutData;

        /// <summary>
        ///     The in string index
        /// </summary>
        public uint InStrIndex;

        /// <summary>
        ///     The in32
        /// </summary>
        public uint In32;

        /// <summary>
        ///     The out32
        /// </summary>
        public uint Out32;

        /// <summary>
        ///     The in64
        /// </summary>
        public ulong In64;

        /// <summary>
        ///     The out64
        /// </summary>
        public ulong Out64;

        /// <summary>
        ///     The string buffer index
        /// </summary>
        public uint StrBufferIndex;

        /// <summary>
        ///     The string buffer chars
        /// </summary>
        public uint StrBufferChars;

        /// <summary>
        ///     The string chars needed
        /// </summary>
        public uint StrCharsNeeded;

        /// <summary>
        ///     The data buffer index
        /// </summary>
        public uint DataBufferIndex;

        /// <summary>
        ///     The data buffer bytes
        /// </summary>
        public uint DataBufferBytes;

        /// <summary>
        ///     The data bytes needed
        /// </summary>
        public uint DataBytesNeeded;

        /// <summary>
        ///     The status
        /// </summary>
        public uint Status;

        /// <summary>
        ///     The reserved
        /// </summary>
        public fixed ulong Reserved[8];
    }

    /// <summary>
    ///     Class EXT_TYPED_DATA.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class EXT_TYPED_DATA
    {
        /// <summary>
        ///     The data buffer bytes
        /// </summary>
        public uint DataBufferBytes;

        /// <summary>
        ///     The data buffer index
        /// </summary>
        public uint DataBufferIndex;

        /// <summary>
        ///     The data bytes needed
        /// </summary>
        public uint DataBytesNeeded;

        /// <summary>
        ///     The flags
        /// </summary>
        public uint Flags;

        /// <summary>
        ///     The in32
        /// </summary>
        public uint In32;

        /// <summary>
        ///     The in64
        /// </summary>
        public ulong In64;

        /// <summary>
        ///     The in data
        /// </summary>
        public _DEBUG_TYPED_DATA InData;

        /// <summary>
        ///     The in string index
        /// </summary>
        public uint InStrIndex;

        /// <summary>
        ///     The operation
        /// </summary>
        public _EXT_TDOP Operation;

        /// <summary>
        ///     The out32
        /// </summary>
        public uint Out32;

        /// <summary>
        ///     The out64
        /// </summary>
        public ulong Out64;

        /// <summary>
        ///     The out data
        /// </summary>
        public _DEBUG_TYPED_DATA OutData;

        /// <summary>
        ///     The status
        /// </summary>
        public uint Status;

        /// <summary>
        ///     The string buffer chars
        /// </summary>
        public uint StrBufferChars;

        /// <summary>
        ///     The string buffer index
        /// </summary>
        public uint StrBufferIndex;

        /// <summary>
        ///     The string chars needed
        /// </summary>
        public uint StrCharsNeeded;
    }

    /// <summary>
    ///     Struct RECT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        ///     The left
        /// </summary>
        public int left;

        /// <summary>
        ///     The top
        /// </summary>
        public int top;

        /// <summary>
        ///     The right
        /// </summary>
        public int right;

        /// <summary>
        ///     The bottom
        /// </summary>
        public int bottom;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_BREAKPOINT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_BREAKPOINT
    {
        /// <summary>
        ///     The identifier
        /// </summary>
        public uint Id;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_EXCEPTION
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXCEPTION
    {
        /// <summary>
        ///     The exception record
        /// </summary>
        public EXCEPTION_RECORD64 ExceptionRecord;

        /// <summary>
        ///     The first chance
        /// </summary>
        public uint FirstChance;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_EXIT_THREAD
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXIT_THREAD
    {
        /// <summary>
        ///     The exit code
        /// </summary>
        public uint ExitCode;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_EXIT_PROCESS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_EXIT_PROCESS
    {
        /// <summary>
        ///     The exit code
        /// </summary>
        public uint ExitCode;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_LOAD_MODULE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_LOAD_MODULE
    {
        /// <summary>
        ///     The base
        /// </summary>
        public ulong Base;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_UNLOAD_MODULE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_UNLOAD_MODULE
    {
        /// <summary>
        ///     The base
        /// </summary>
        public ulong Base;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO_SYSTEM_ERROR
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_SYSTEM_ERROR
    {
        /// <summary>
        ///     The error
        /// </summary>
        public uint Error;

        /// <summary>
        ///     The level
        /// </summary>
        public uint Level;
    }

    /// <summary>
    ///     Struct DEBUG_LAST_EVENT_INFO
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DEBUG_LAST_EVENT_INFO
    {
        /// <summary>
        ///     The breakpoint
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_BREAKPOINT Breakpoint;

        /// <summary>
        ///     The exception
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_EXCEPTION Exception;

        /// <summary>
        ///     The exit thread
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_EXIT_THREAD ExitThread;

        /// <summary>
        ///     The exit process
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_EXIT_PROCESS ExitProcess;

        /// <summary>
        ///     The load module
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_LOAD_MODULE LoadModule;

        /// <summary>
        ///     The unload module
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_UNLOAD_MODULE UnloadModule;

        /// <summary>
        ///     The system error
        /// </summary>
        [FieldOffset(0)] public DEBUG_LAST_EVENT_INFO_SYSTEM_ERROR SystemError;
    }

    /// <summary>
    ///     Struct DEBUG_EVENT_CONTEXT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_EVENT_CONTEXT
    {
        /// <summary>
        ///     The size
        /// </summary>
        public uint Size;

        /// <summary>
        ///     The process engine identifier
        /// </summary>
        public uint ProcessEngineId;

        /// <summary>
        ///     The thread engine identifier
        /// </summary>
        public uint ThreadEngineId;

        /// <summary>
        ///     The frame engine identifier
        /// </summary>
        public uint FrameEngineId;
    }
}