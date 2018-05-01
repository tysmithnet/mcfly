// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="Enums.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Enum SymTag
    /// </summary>
    public enum SymTag : uint
    {
        /// <summary>
        ///     The null
        /// </summary>
        Null, //  0

        /// <summary>
        ///     The executable
        /// </summary>
        Exe, //  1

        /// <summary>
        ///     The compiland
        /// </summary>
        Compiland, //  2

        /// <summary>
        ///     The compiland details
        /// </summary>
        CompilandDetails, //  3

        /// <summary>
        ///     The compiland env
        /// </summary>
        CompilandEnv, //  4

        /// <summary>
        ///     The function
        /// </summary>
        Function, //  5

        /// <summary>
        ///     The block
        /// </summary>
        Block, //  6

        /// <summary>
        ///     The data
        /// </summary>
        Data, //  7

        /// <summary>
        ///     The annotation
        /// </summary>
        Annotation, //  8

        /// <summary>
        ///     The label
        /// </summary>
        Label, //  9

        /// <summary>
        ///     The public symbol
        /// </summary>
        PublicSymbol, // 10

        /// <summary>
        ///     The udt
        /// </summary>
        UDT, // 11

        /// <summary>
        ///     The enum
        /// </summary>
        Enum, // 12

        /// <summary>
        ///     The function type
        /// </summary>
        FunctionType, // 13

        /// <summary>
        ///     The pointer type
        /// </summary>
        PointerType, // 14

        /// <summary>
        ///     The array type
        /// </summary>
        ArrayType, // 15

        /// <summary>
        ///     The base type
        /// </summary>
        BaseType, // 16

        /// <summary>
        ///     The typedef
        /// </summary>
        Typedef, // 17

        /// <summary>
        ///     The base class
        /// </summary>
        BaseClass, // 18

        /// <summary>
        ///     The friend
        /// </summary>
        Friend, // 19

        /// <summary>
        ///     The function argument type
        /// </summary>
        FunctionArgType, // 20

        /// <summary>
        ///     The function debug start
        /// </summary>
        FuncDebugStart, // 21

        /// <summary>
        ///     The function debug end
        /// </summary>
        FuncDebugEnd, // 22

        /// <summary>
        ///     The using namespace
        /// </summary>
        UsingNamespace, // 23

        /// <summary>
        ///     The v table shape
        /// </summary>
        VTableShape, // 24

        /// <summary>
        ///     The v table
        /// </summary>
        VTable, // 25

        /// <summary>
        ///     The custom
        /// </summary>
        Custom, // 26

        /// <summary>
        ///     The thunk
        /// </summary>
        Thunk, // 27

        /// <summary>
        ///     The custom type
        /// </summary>
        CustomType, // 28

        /// <summary>
        ///     The managed type
        /// </summary>
        ManagedType, // 29

        /// <summary>
        ///     The dimension
        /// </summary>
        Dimension, // 30

        /// <summary>
        ///     The call site
        /// </summary>
        CallSite, // 31

        /// <summary>
        ///     The inline site
        /// </summary>
        InlineSite, // 32

        /// <summary>
        ///     The base interface
        /// </summary>
        BaseInterface, // 33

        /// <summary>
        ///     The vector type
        /// </summary>
        VectorType, // 34

        /// <summary>
        ///     The matrix type
        /// </summary>
        MatrixType, // 35

        /// <summary>
        ///     The HLSL type
        /// </summary>
        HLSLType, // 36

        /// <summary>
        ///     The sym tag maximum
        /// </summary>
        SymTagMax
    }

    /// <summary>
    ///     Enum DEBUG_REQUEST
    /// </summary>
    public enum DEBUG_REQUEST : uint
    {
        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The source path has source server
        /// </summary>
        SOURCE_PATH_HAS_SOURCE_SERVER = 0,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Machine-specific CONTEXT.
        /// </summary>
        /// <summary>
        ///     The target exception context
        /// </summary>
        TARGET_EXCEPTION_CONTEXT = 1,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - ULONG system ID of thread.
        /// </summary>
        /// <summary>
        ///     The target exception thread
        /// </summary>
        TARGET_EXCEPTION_THREAD = 2,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - EXCEPTION_RECORD64.
        /// </summary>
        /// <summary>
        ///     The target exception record
        /// </summary>
        TARGET_EXCEPTION_RECORD = 3,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - DEBUG_CREATE_PROCESS_OPTIONS.
        /// </summary>
        /// <summary>
        ///     The get additional create options
        /// </summary>
        GET_ADDITIONAL_CREATE_OPTIONS = 4,

        /// <summary>
        ///     InBuffer - DEBUG_CREATE_PROCESS_OPTIONS.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The set additional create options
        /// </summary>
        SET_ADDITIONAL_CREATE_OPTIONS = 5,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - ULONG[2] major/minor.
        /// </summary>
        /// <summary>
        ///     The get wi N32 major minor versions
        /// </summary>
        GET_WIN32_MAJOR_MINOR_VERSIONS = 6,

        /// <summary>
        ///     InBuffer - DEBUG_READ_USER_MINIDUMP_STREAM.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The read user minidump stream
        /// </summary>
        READ_USER_MINIDUMP_STREAM = 7,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The target can detach
        /// </summary>
        TARGET_CAN_DETACH = 8,

        /// <summary>
        ///     InBuffer - PTSTR.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The set local implicit command line
        /// </summary>
        SET_LOCAL_IMPLICIT_COMMAND_LINE = 9,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Event code stream offset.
        /// </summary>
        /// <summary>
        ///     The get captured event code offset
        /// </summary>
        GET_CAPTURED_EVENT_CODE_OFFSET = 10,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Event code stream information.
        /// </summary>
        /// <summary>
        ///     The read captured event code stream
        /// </summary>
        READ_CAPTURED_EVENT_CODE_STREAM = 11,

        /// <summary>
        ///     InBuffer - Input data block.
        ///     OutBuffer - Processed data block.
        /// </summary>
        /// <summary>
        ///     The ext typed data ANSI
        /// </summary>
        EXT_TYPED_DATA_ANSI = 12,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Returned path.
        /// </summary>
        /// <summary>
        ///     The get extension search path wide
        /// </summary>
        GET_EXTENSION_SEARCH_PATH_WIDE = 13,

        /// <summary>
        ///     InBuffer - DEBUG_GET_TEXT_COMPLETIONS_IN.
        ///     OutBuffer - DEBUG_GET_TEXT_COMPLETIONS_OUT.
        /// </summary>
        /// <summary>
        ///     The get text completions wide
        /// </summary>
        GET_TEXT_COMPLETIONS_WIDE = 14,

        /// <summary>
        ///     InBuffer - ULONG64 cookie.
        ///     OutBuffer - DEBUG_CACHED_SYMBOL_INFO.
        /// </summary>
        /// <summary>
        ///     The get cached symbol information
        /// </summary>
        GET_CACHED_SYMBOL_INFO = 15,

        /// <summary>
        ///     InBuffer - DEBUG_CACHED_SYMBOL_INFO.
        ///     OutBuffer - ULONG64 cookie.
        /// </summary>
        /// <summary>
        ///     The add cached symbol information
        /// </summary>
        ADD_CACHED_SYMBOL_INFO = 16,

        /// <summary>
        ///     InBuffer - ULONG64 cookie.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The remove cached symbol information
        /// </summary>
        REMOVE_CACHED_SYMBOL_INFO = 17,

        /// <summary>
        ///     InBuffer - DEBUG_GET_TEXT_COMPLETIONS_IN.
        ///     OutBuffer - DEBUG_GET_TEXT_COMPLETIONS_OUT.
        /// </summary>
        /// <summary>
        ///     The get text completions ANSI
        /// </summary>
        GET_TEXT_COMPLETIONS_ANSI = 18,

        /// <summary>
        ///     InBuffer - Unused.
        ///     OutBuffer - Unused.
        /// </summary>
        /// <summary>
        ///     The current output callbacks are DML aware
        /// </summary>
        CURRENT_OUTPUT_CALLBACKS_ARE_DML_AWARE = 19,

        /// <summary>
        ///     InBuffer - ULONG64 offset.
        ///     OutBuffer - Unwind information.
        /// </summary>
        /// <summary>
        ///     The get offset unwind information
        /// </summary>
        GET_OFFSET_UNWIND_INFORMATION = 20,

        /// <summary>
        ///     InBuffer - Unused
        ///     OutBuffer - returned DUMP_HEADER32/DUMP_HEADER64 structure.
        /// </summary>
        /// <summary>
        ///     The get dump header
        /// </summary>
        GET_DUMP_HEADER = 21,

        /// <summary>
        ///     InBuffer - DUMP_HEADER32/DUMP_HEADER64 structure.
        ///     OutBuffer - Unused
        /// </summary>
        /// <summary>
        ///     The set dump header
        /// </summary>
        SET_DUMP_HEADER = 22,

        /// <summary>
        ///     InBuffer - Midori specific
        ///     OutBuffer - Midori specific
        /// </summary>
        /// <summary>
        ///     The midori
        /// </summary>
        MIDORI = 23,

        /// <summary>
        ///     InBuffer - Unused
        ///     OutBuffer - PROCESS_NAME_ENTRY blocks
        /// </summary>
        /// <summary>
        ///     The process descriptors
        /// </summary>
        PROCESS_DESCRIPTORS = 24,

        /// <summary>
        ///     InBuffer - Unused
        ///     OutBuffer - MINIDUMP_MISC_INFO_N blocks
        /// </summary>
        /// <summary>
        ///     The misc information
        /// </summary>
        MISC_INFORMATION = 25,

        /// <summary>
        ///     InBuffer - Unused
        ///     OutBuffer - ULONG64 as TokenHandle value
        /// </summary>
        /// <summary>
        ///     The open process token
        /// </summary>
        OPEN_PROCESS_TOKEN = 26,

        /// <summary>
        ///     InBuffer - Unused
        ///     OutBuffer - ULONG64 as TokenHandle value
        /// </summary>
        /// <summary>
        ///     The open thread token
        /// </summary>
        OPEN_THREAD_TOKEN = 27,

        /// <summary>
        ///     InBuffer -  ULONG64 as TokenHandle being duplicated
        ///     OutBuffer - ULONG64 as new duplicated TokenHandle
        /// </summary>
        /// <summary>
        ///     The duplicate token
        /// </summary>
        DUPLICATE_TOKEN = 28,

        /// <summary>
        ///     InBuffer - a ULONG64 as TokenHandle and a ULONG as NtQueryInformationToken() request code
        ///     OutBuffer - NtQueryInformationToken() return
        /// </summary>
        /// <summary>
        ///     The query information token
        /// </summary>
        QUERY_INFO_TOKEN = 29,

        /// <summary>
        ///     InBuffer - ULONG64 as TokenHandle
        ///     OutBuffer - Unused
        /// </summary>
        /// <summary>
        ///     The close token
        /// </summary>
        CLOSE_TOKEN = 30,

        /// <summary>
        ///     InBuffer - ULONG64 for process server identification and ULONG as PID
        ///     OutBuffer - Unused
        /// </summary>
        /// <summary>
        ///     The wow process
        /// </summary>
        WOW_PROCESS = 31,

        /// <summary>
        ///     InBuffer - ULONG64 for process server identification and PWSTR as module path
        ///     OutBuffer - Unused
        /// </summary>
        /// <summary>
        ///     The wow module
        /// </summary>
        WOW_MODULE = 32,

        /// <summary>
        ///     InBuffer - Unused
        ///     OutBuffer - Unused
        ///     return - S_OK if non-invasive user-mode attach, S_FALSE if not (but still live user-mode), E_FAIL otherwise.
        /// </summary>
        /// <summary>
        ///     The live user non invasive
        /// </summary>
        LIVE_USER_NON_INVASIVE = 33,

        /// <summary>
        ///     InBuffer - TID
        ///     OutBuffer - Unused
        ///     return - ResumeThreads() return.
        /// </summary>
        /// <summary>
        ///     The resume thread
        /// </summary>
        RESUME_THREAD = 34
    }

    /// <summary>
    ///     Enum DEBUG_SRCFILE
    /// </summary>
    public enum DEBUG_SRCFILE : uint
    {
        /// <summary>
        ///     The symbol token
        /// </summary>
        SYMBOL_TOKEN = 0,

        /// <summary>
        ///     The symbol token source command wide
        /// </summary>
        SYMBOL_TOKEN_SOURCE_COMMAND_WIDE = 1
    }

    /// <summary>
    ///     Enum DEBUG_SYMINFO
    /// </summary>
    public enum DEBUG_SYMINFO : uint
    {
        /// <summary>
        ///     The breakpoint source line
        /// </summary>
        BREAKPOINT_SOURCE_LINE = 0,

        /// <summary>
        ///     The imagehlp module W64
        /// </summary>
        IMAGEHLP_MODULEW64 = 1,

        /// <summary>
        ///     The get symbol name by offset and tag wide
        /// </summary>
        GET_SYMBOL_NAME_BY_OFFSET_AND_TAG_WIDE = 2,

        /// <summary>
        ///     The get module symbol names and offsets
        /// </summary>
        GET_MODULE_SYMBOL_NAMES_AND_OFFSETS = 3
    }

    /// <summary>
    ///     Enum DEBUG_SYSOBJINFO
    /// </summary>
    public enum DEBUG_SYSOBJINFO : uint
    {
        /// <summary>
        ///     The thread basic information
        /// </summary>
        THREAD_BASIC_INFORMATION = 0,

        /// <summary>
        ///     The thread name wide
        /// </summary>
        THREAD_NAME_WIDE = 1,

        /// <summary>
        ///     The current process cookie
        /// </summary>
        CURRENT_PROCESS_COOKIE = 2
    }

    /// <summary>
    ///     Enum DEBUG_TBINFO
    /// </summary>
    [Flags]
    public enum DEBUG_TBINFO : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     The exit status
        /// </summary>
        EXIT_STATUS = 1,

        /// <summary>
        ///     The priority class
        /// </summary>
        PRIORITY_CLASS = 2,

        /// <summary>
        ///     The priority
        /// </summary>
        PRIORITY = 4,

        /// <summary>
        ///     The times
        /// </summary>
        TIMES = 8,

        /// <summary>
        ///     The start offset
        /// </summary>
        START_OFFSET = 0x10,

        /// <summary>
        ///     The affinity
        /// </summary>
        AFFINITY = 0x20,

        /// <summary>
        ///     All
        /// </summary>
        ALL = 0x3f
    }

    /// <summary>
    ///     Enum DEBUG_GET_TEXT_COMPLETIONS
    /// </summary>
    [Flags]
    public enum DEBUG_GET_TEXT_COMPLETIONS : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     The no dot commands
        /// </summary>
        NO_DOT_COMMANDS = 1,

        /// <summary>
        ///     The no extension commands
        /// </summary>
        NO_EXTENSION_COMMANDS = 2,

        /// <summary>
        ///     The no symbols
        /// </summary>
        NO_SYMBOLS = 4,

        /// <summary>
        ///     The is dot command
        /// </summary>
        IS_DOT_COMMAND = 1,

        /// <summary>
        ///     The is extension command
        /// </summary>
        IS_EXTENSION_COMMAND = 2,

        /// <summary>
        ///     The is symbol
        /// </summary>
        IS_SYMBOL = 4
    }

    /// <summary>
    ///     Enum DEBUG_CLASS
    /// </summary>
    public enum DEBUG_CLASS : uint
    {
        /// <summary>
        ///     The uninitialized
        /// </summary>
        UNINITIALIZED = 0,

        /// <summary>
        ///     The kernel
        /// </summary>
        KERNEL = 1,

        /// <summary>
        ///     The user windows
        /// </summary>
        USER_WINDOWS = 2,

        /// <summary>
        ///     The image file
        /// </summary>
        IMAGE_FILE = 3
    }

    /// <summary>
    ///     Enum DEBUG_CLASS_QUALIFIER
    /// </summary>
    public enum DEBUG_CLASS_QUALIFIER : uint
    {
        /// <summary>
        ///     The kernel connection
        /// </summary>
        KERNEL_CONNECTION = 0,

        /// <summary>
        ///     The kernel local
        /// </summary>
        KERNEL_LOCAL = 1,

        /// <summary>
        ///     The kernel exdi driver
        /// </summary>
        KERNEL_EXDI_DRIVER = 2,

        /// <summary>
        ///     The kernel idna
        /// </summary>
        KERNEL_IDNA = 3,

        /// <summary>
        ///     The kernel small dump
        /// </summary>
        KERNEL_SMALL_DUMP = 1024,

        /// <summary>
        ///     The kernel dump
        /// </summary>
        KERNEL_DUMP = 1025,

        /// <summary>
        ///     The kernel full dump
        /// </summary>
        KERNEL_FULL_DUMP = 1026,

        /// <summary>
        ///     The user windows process
        /// </summary>
        USER_WINDOWS_PROCESS = 0,

        /// <summary>
        ///     The user windows process server
        /// </summary>
        USER_WINDOWS_PROCESS_SERVER = 1,

        /// <summary>
        ///     The user windows idna
        /// </summary>
        USER_WINDOWS_IDNA = 2,

        /// <summary>
        ///     The user windows small dump
        /// </summary>
        USER_WINDOWS_SMALL_DUMP = 1024,

        /// <summary>
        ///     The user windows dump
        /// </summary>
        USER_WINDOWS_DUMP = 1026
    }

    /// <summary>
    ///     Enum DEBUG_ATTACH
    /// </summary>
    [Flags]
    public enum DEBUG_ATTACH : uint
    {
        /// <summary>
        ///     The kernel connection
        /// </summary>
        KERNEL_CONNECTION = 0,

        /// <summary>
        ///     The local kernel
        /// </summary>
        LOCAL_KERNEL = 1,

        /// <summary>
        ///     The exdi driver
        /// </summary>
        EXDI_DRIVER = 2,

        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The noninvasive
        /// </summary>
        NONINVASIVE = 1,

        /// <summary>
        ///     The existing
        /// </summary>
        EXISTING = 2,

        /// <summary>
        ///     The noninvasive no suspend
        /// </summary>
        NONINVASIVE_NO_SUSPEND = 4,

        /// <summary>
        ///     The invasive no initial break
        /// </summary>
        INVASIVE_NO_INITIAL_BREAK = 8,

        /// <summary>
        ///     The invasive resume process
        /// </summary>
        INVASIVE_RESUME_PROCESS = 0x10,

        /// <summary>
        ///     The noninvasive allow partial
        /// </summary>
        NONINVASIVE_ALLOW_PARTIAL = 0x20
    }

    /// <summary>
    ///     Enum DEBUG_GET_PROC
    /// </summary>
    [Flags]
    public enum DEBUG_GET_PROC : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The full match
        /// </summary>
        FULL_MATCH = 1,

        /// <summary>
        ///     The only match
        /// </summary>
        ONLY_MATCH = 2,

        /// <summary>
        ///     The service name
        /// </summary>
        SERVICE_NAME = 4
    }

    /// <summary>
    ///     Enum DEBUG_PROC_DESC
    /// </summary>
    [Flags]
    public enum DEBUG_PROC_DESC : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no paths
        /// </summary>
        NO_PATHS = 1,

        /// <summary>
        ///     The no services
        /// </summary>
        NO_SERVICES = 2,

        /// <summary>
        ///     The no MTS packages
        /// </summary>
        NO_MTS_PACKAGES = 4,

        /// <summary>
        ///     The no command line
        /// </summary>
        NO_COMMAND_LINE = 8,

        /// <summary>
        ///     The no session identifier
        /// </summary>
        NO_SESSION_ID = 0x10,

        /// <summary>
        ///     The no user name
        /// </summary>
        NO_USER_NAME = 0x20
    }

    /// <summary>
    ///     Enum DEBUG_CREATE_PROCESS
    /// </summary>
    [Flags]
    public enum DEBUG_CREATE_PROCESS : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no debug heap
        /// </summary>
        NO_DEBUG_HEAP = 0x00000400, /* CREATE_UNICODE_ENVIRONMENT */

        /// <summary>
        ///     The through RTL
        /// </summary>
        THROUGH_RTL = 0x00010000 /* STACK_SIZE_PARAM_IS_A_RESERVATION */
    }

    /// <summary>
    ///     Enum DEBUG_ECREATE_PROCESS
    /// </summary>
    [Flags]
    public enum DEBUG_ECREATE_PROCESS : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The inherit handles
        /// </summary>
        INHERIT_HANDLES = 1,

        /// <summary>
        ///     The use verifier flags
        /// </summary>
        USE_VERIFIER_FLAGS = 2,

        /// <summary>
        ///     The use implicit command line
        /// </summary>
        USE_IMPLICIT_COMMAND_LINE = 4
    }

    /// <summary>
    ///     Enum DEBUG_PROCESS
    /// </summary>
    [Flags]
    public enum DEBUG_PROCESS : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The detach on exit
        /// </summary>
        DETACH_ON_EXIT = 1,

        /// <summary>
        ///     The only this process
        /// </summary>
        ONLY_THIS_PROCESS = 2
    }

    /// <summary>
    ///     Enum DEBUG_DUMP
    /// </summary>
    public enum DEBUG_DUMP : uint
    {
        /// <summary>
        ///     The small
        /// </summary>
        SMALL = 1024,

        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 1025,

        /// <summary>
        ///     The full
        /// </summary>
        FULL = 1026,

        /// <summary>
        ///     The image file
        /// </summary>
        IMAGE_FILE = 1027,

        /// <summary>
        ///     The trace log
        /// </summary>
        TRACE_LOG = 1028,

        /// <summary>
        ///     The windows cd
        /// </summary>
        WINDOWS_CD = 1029,

        /// <summary>
        ///     The kernel dump
        /// </summary>
        KERNEL_DUMP = 1025,

        /// <summary>
        ///     The kernel small dump
        /// </summary>
        KERNEL_SMALL_DUMP = 1024,

        /// <summary>
        ///     The kernel full dump
        /// </summary>
        KERNEL_FULL_DUMP = 1026
    }

    /// <summary>
    ///     Enum DEBUG_CONNECT_SESSION
    /// </summary>
    [Flags]
    public enum DEBUG_CONNECT_SESSION : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no version
        /// </summary>
        NO_VERSION = 1,

        /// <summary>
        ///     The no announce
        /// </summary>
        NO_ANNOUNCE = 2
    }

    /// <summary>
    ///     Enum DEBUG_OUTCTL
    /// </summary>
    [Flags]
    public enum DEBUG_OUTCTL : uint
    {
        /// <summary>
        ///     The this client
        /// </summary>
        THIS_CLIENT = 0,

        /// <summary>
        ///     All clients
        /// </summary>
        ALL_CLIENTS = 1,

        /// <summary>
        ///     All other clients
        /// </summary>
        ALL_OTHER_CLIENTS = 2,

        /// <summary>
        ///     The ignore
        /// </summary>
        IGNORE = 3,

        /// <summary>
        ///     The log only
        /// </summary>
        LOG_ONLY = 4,

        /// <summary>
        ///     The send mask
        /// </summary>
        SEND_MASK = 7,

        /// <summary>
        ///     The not logged
        /// </summary>
        NOT_LOGGED = 8,

        /// <summary>
        ///     The override mask
        /// </summary>
        OVERRIDE_MASK = 0x10,

        /// <summary>
        ///     The DML
        /// </summary>
        DML = 0x20,

        /// <summary>
        ///     The ambient DML
        /// </summary>
        AMBIENT_DML = 0xfffffffe,

        /// <summary>
        ///     The ambient text
        /// </summary>
        AMBIENT_TEXT = 0xffffffff
    }

    /// <summary>
    ///     Enum DEBUG_SERVERS
    /// </summary>
    public enum DEBUG_SERVERS : uint
    {
        /// <summary>
        ///     The debugger
        /// </summary>
        DEBUGGER = 1,

        /// <summary>
        ///     The process
        /// </summary>
        PROCESS = 2,

        /// <summary>
        ///     All
        /// </summary>
        ALL = 3
    }

    /// <summary>
    ///     Enum DEBUG_END
    /// </summary>
    public enum DEBUG_END : uint
    {
        /// <summary>
        ///     The passive
        /// </summary>
        PASSIVE = 0,

        /// <summary>
        ///     The active terminate
        /// </summary>
        ACTIVE_TERMINATE = 1,

        /// <summary>
        ///     The active detach
        /// </summary>
        ACTIVE_DETACH = 2,

        /// <summary>
        ///     The end reentrant
        /// </summary>
        END_REENTRANT = 3,

        /// <summary>
        ///     The end disconnect
        /// </summary>
        END_DISCONNECT = 4
    }

    /// <summary>
    ///     Enum DEBUG_OUTPUT
    /// </summary>
    [Flags]
    public enum DEBUG_OUTPUT : uint
    {
        /// <summary>
        ///     The normal
        /// </summary>
        NORMAL = 1,

        /// <summary>
        ///     The error
        /// </summary>
        ERROR = 2,

        /// <summary>
        ///     The warning
        /// </summary>
        WARNING = 4,

        /// <summary>
        ///     The verbose
        /// </summary>
        VERBOSE = 8,

        /// <summary>
        ///     The prompt
        /// </summary>
        PROMPT = 0x10,

        /// <summary>
        ///     The prompt registers
        /// </summary>
        PROMPT_REGISTERS = 0x20,

        /// <summary>
        ///     The extension warning
        /// </summary>
        EXTENSION_WARNING = 0x40,

        /// <summary>
        ///     The debuggee
        /// </summary>
        DEBUGGEE = 0x80,

        /// <summary>
        ///     The debuggee prompt
        /// </summary>
        DEBUGGEE_PROMPT = 0x100,

        /// <summary>
        ///     The symbols
        /// </summary>
        SYMBOLS = 0x200
    }

    /// <summary>
    ///     Enum DEBUG_EVENT
    /// </summary>
    [Flags]
    public enum DEBUG_EVENT : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     The breakpoint
        /// </summary>
        BREAKPOINT = 1,

        /// <summary>
        ///     The exception
        /// </summary>
        EXCEPTION = 2,

        /// <summary>
        ///     The create thread
        /// </summary>
        CREATE_THREAD = 4,

        /// <summary>
        ///     The exit thread
        /// </summary>
        EXIT_THREAD = 8,

        /// <summary>
        ///     The create process
        /// </summary>
        CREATE_PROCESS = 0x10,

        /// <summary>
        ///     The exit process
        /// </summary>
        EXIT_PROCESS = 0x20,

        /// <summary>
        ///     The load module
        /// </summary>
        LOAD_MODULE = 0x40,

        /// <summary>
        ///     The unload module
        /// </summary>
        UNLOAD_MODULE = 0x80,

        /// <summary>
        ///     The system error
        /// </summary>
        SYSTEM_ERROR = 0x100,

        /// <summary>
        ///     The session status
        /// </summary>
        SESSION_STATUS = 0x200,

        /// <summary>
        ///     The change debuggee state
        /// </summary>
        CHANGE_DEBUGGEE_STATE = 0x400,

        /// <summary>
        ///     The change engine state
        /// </summary>
        CHANGE_ENGINE_STATE = 0x800,

        /// <summary>
        ///     The change symbol state
        /// </summary>
        CHANGE_SYMBOL_STATE = 0x1000
    }

    /// <summary>
    ///     Enum DEBUG_SESSION
    /// </summary>
    public enum DEBUG_SESSION : uint
    {
        /// <summary>
        ///     The active
        /// </summary>
        ACTIVE = 0,

        /// <summary>
        ///     The end session active terminate
        /// </summary>
        END_SESSION_ACTIVE_TERMINATE = 1,

        /// <summary>
        ///     The end session active detach
        /// </summary>
        END_SESSION_ACTIVE_DETACH = 2,

        /// <summary>
        ///     The end session passive
        /// </summary>
        END_SESSION_PASSIVE = 3,

        /// <summary>
        ///     The end
        /// </summary>
        END = 4,

        /// <summary>
        ///     The reboot
        /// </summary>
        REBOOT = 5,

        /// <summary>
        ///     The hibernate
        /// </summary>
        HIBERNATE = 6,

        /// <summary>
        ///     The failure
        /// </summary>
        FAILURE = 7
    }

    /// <summary>
    ///     Enum DEBUG_CDS
    /// </summary>
    [Flags]
    public enum DEBUG_CDS : uint
    {
        /// <summary>
        ///     All
        /// </summary>
        ALL = 0xffffffff,

        /// <summary>
        ///     The registers
        /// </summary>
        REGISTERS = 1,

        /// <summary>
        ///     The data
        /// </summary>
        DATA = 2,

        /// <summary>
        ///     The refresh
        /// </summary>
        REFRESH = 4 // Inform the GUI clients to refresh debugger windows.
    }

    // What windows should the GUI client refresh?
    /// <summary>
    ///     Enum DEBUG_CDS_REFRESH
    /// </summary>
    [Flags]
    public enum DEBUG_CDS_REFRESH : uint
    {
        /// <summary>
        ///     The evaluate
        /// </summary>
        EVALUATE = 1,

        /// <summary>
        ///     The execute
        /// </summary>
        EXECUTE = 2,

        /// <summary>
        ///     The executecommandfile
        /// </summary>
        EXECUTECOMMANDFILE = 3,

        /// <summary>
        ///     The addbreakpoint
        /// </summary>
        ADDBREAKPOINT = 4,

        /// <summary>
        ///     The removebreakpoint
        /// </summary>
        REMOVEBREAKPOINT = 5,

        /// <summary>
        ///     The writevirtual
        /// </summary>
        WRITEVIRTUAL = 6,

        /// <summary>
        ///     The writevirtualuncached
        /// </summary>
        WRITEVIRTUALUNCACHED = 7,

        /// <summary>
        ///     The writephysical
        /// </summary>
        WRITEPHYSICAL = 8,

        /// <summary>
        ///     The writephysica l2
        /// </summary>
        WRITEPHYSICAL2 = 9,

        /// <summary>
        ///     The setvalue
        /// </summary>
        SETVALUE = 10,

        /// <summary>
        ///     The setvalu e2
        /// </summary>
        SETVALUE2 = 11,

        /// <summary>
        ///     The setscope
        /// </summary>
        SETSCOPE = 12,

        /// <summary>
        ///     The setscopeframebyindex
        /// </summary>
        SETSCOPEFRAMEBYINDEX = 13,

        /// <summary>
        ///     The setscopefromjitdebuginfo
        /// </summary>
        SETSCOPEFROMJITDEBUGINFO = 14,

        /// <summary>
        ///     The setscopefromstoredevent
        /// </summary>
        SETSCOPEFROMSTOREDEVENT = 15,

        /// <summary>
        ///     The inlinestep
        /// </summary>
        INLINESTEP = 16,

        /// <summary>
        ///     The inlinestep pseudo
        /// </summary>
        INLINESTEP_PSEUDO = 17
    }

    /// <summary>
    ///     Enum DEBUG_CES
    /// </summary>
    [Flags]
    public enum DEBUG_CES : uint
    {
        /// <summary>
        ///     All
        /// </summary>
        ALL = 0xffffffff,

        /// <summary>
        ///     The current thread
        /// </summary>
        CURRENT_THREAD = 1,

        /// <summary>
        ///     The effective processor
        /// </summary>
        EFFECTIVE_PROCESSOR = 2,

        /// <summary>
        ///     The breakpoints
        /// </summary>
        BREAKPOINTS = 4,

        /// <summary>
        ///     The code level
        /// </summary>
        CODE_LEVEL = 8,

        /// <summary>
        ///     The execution status
        /// </summary>
        EXECUTION_STATUS = 0x10,

        /// <summary>
        ///     The engine options
        /// </summary>
        ENGINE_OPTIONS = 0x20,

        /// <summary>
        ///     The log file
        /// </summary>
        LOG_FILE = 0x40,

        /// <summary>
        ///     The radix
        /// </summary>
        RADIX = 0x80,

        /// <summary>
        ///     The event filters
        /// </summary>
        EVENT_FILTERS = 0x100,

        /// <summary>
        ///     The process options
        /// </summary>
        PROCESS_OPTIONS = 0x200,

        /// <summary>
        ///     The extensions
        /// </summary>
        EXTENSIONS = 0x400,

        /// <summary>
        ///     The systems
        /// </summary>
        SYSTEMS = 0x800,

        /// <summary>
        ///     The assembly options
        /// </summary>
        ASSEMBLY_OPTIONS = 0x1000,

        /// <summary>
        ///     The expression syntax
        /// </summary>
        EXPRESSION_SYNTAX = 0x2000,

        /// <summary>
        ///     The text replacements
        /// </summary>
        TEXT_REPLACEMENTS = 0x4000
    }

    /// <summary>
    ///     Enum DEBUG_CSS
    /// </summary>
    [Flags]
    public enum DEBUG_CSS : uint
    {
        /// <summary>
        ///     All
        /// </summary>
        ALL = 0xffffffff,

        /// <summary>
        ///     The loads
        /// </summary>
        LOADS = 1,

        /// <summary>
        ///     The unloads
        /// </summary>
        UNLOADS = 2,

        /// <summary>
        ///     The scope
        /// </summary>
        SCOPE = 4,

        /// <summary>
        ///     The paths
        /// </summary>
        PATHS = 8,

        /// <summary>
        ///     The symbol options
        /// </summary>
        SYMBOL_OPTIONS = 0x10,

        /// <summary>
        ///     The type options
        /// </summary>
        TYPE_OPTIONS = 0x20
    }

    /// <summary>
    ///     Enum DEBUG_BREAKPOINT_TYPE
    /// </summary>
    public enum DEBUG_BREAKPOINT_TYPE : uint
    {
        /// <summary>
        ///     The code
        /// </summary>
        CODE = 0,

        /// <summary>
        ///     The data
        /// </summary>
        DATA = 1,

        /// <summary>
        ///     The time
        /// </summary>
        TIME = 2
    }

    /// <summary>
    ///     Enum DEBUG_BREAKPOINT_FLAG
    /// </summary>
    [Flags]
    public enum DEBUG_BREAKPOINT_FLAG : uint
    {
        /// <summary>
        ///     The go only
        /// </summary>
        GO_ONLY = 1,

        /// <summary>
        ///     The deferred
        /// </summary>
        DEFERRED = 2,

        /// <summary>
        ///     The enabled
        /// </summary>
        ENABLED = 4,

        /// <summary>
        ///     The adder only
        /// </summary>
        ADDER_ONLY = 8,

        /// <summary>
        ///     The one shot
        /// </summary>
        ONE_SHOT = 0x10
    }

    /// <summary>
    ///     Enum DEBUG_BREAKPOINT_ACCESS_TYPE
    /// </summary>
    [Flags]
    public enum DEBUG_BREAKPOINT_ACCESS_TYPE : uint
    {
        /// <summary>
        ///     The read
        /// </summary>
        READ = 1,

        /// <summary>
        ///     The write
        /// </summary>
        WRITE = 2,

        /// <summary>
        ///     The execute
        /// </summary>
        EXECUTE = 4,

        /// <summary>
        ///     The io
        /// </summary>
        IO = 8
    }

    /// <summary>
    ///     Enum DEBUG_REGISTERS
    /// </summary>
    [Flags]
    public enum DEBUG_REGISTERS : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The in T32
        /// </summary>
        INT32 = 1,

        /// <summary>
        ///     The in T64
        /// </summary>
        INT64 = 2,

        /// <summary>
        ///     The float
        /// </summary>
        FLOAT = 4,

        /// <summary>
        ///     All
        /// </summary>
        ALL = 7
    }

    /// <summary>
    ///     Enum DEBUG_REGISTER
    /// </summary>
    [Flags]
    public enum DEBUG_REGISTER : uint
    {
        /// <summary>
        ///     The sub register
        /// </summary>
        SUB_REGISTER = 1
    }

    /// <summary>
    ///     Enum DEBUG_VALUE_TYPE
    /// </summary>
    public enum DEBUG_VALUE_TYPE : uint
    {
        /// <summary>
        ///     The invalid
        /// </summary>
        INVALID = 0,

        /// <summary>
        ///     The in t8
        /// </summary>
        INT8 = 1,

        /// <summary>
        ///     The in T16
        /// </summary>
        INT16 = 2,

        /// <summary>
        ///     The in T32
        /// </summary>
        INT32 = 3,

        /// <summary>
        ///     The in T64
        /// </summary>
        INT64 = 4,

        /// <summary>
        ///     The floa T32
        /// </summary>
        FLOAT32 = 5,

        /// <summary>
        ///     The floa T64
        /// </summary>
        FLOAT64 = 6,

        /// <summary>
        ///     The floa T80
        /// </summary>
        FLOAT80 = 7,

        /// <summary>
        ///     The floa T82
        /// </summary>
        FLOAT82 = 8,

        /// <summary>
        ///     The floa T128
        /// </summary>
        FLOAT128 = 9,

        /// <summary>
        ///     The vecto R64
        /// </summary>
        VECTOR64 = 10,

        /// <summary>
        ///     The vecto R128
        /// </summary>
        VECTOR128 = 11,

        /// <summary>
        ///     The types
        /// </summary>
        TYPES = 12
    }

    /// <summary>
    ///     Enum INTERFACE_TYPE
    /// </summary>
    public enum INTERFACE_TYPE
    {
        /// <summary>
        ///     The interface type undefined
        /// </summary>
        InterfaceTypeUndefined = -1,

        /// <summary>
        ///     The internal
        /// </summary>
        Internal,

        /// <summary>
        ///     The isa
        /// </summary>
        Isa,

        /// <summary>
        ///     The eisa
        /// </summary>
        Eisa,

        /// <summary>
        ///     The micro channel
        /// </summary>
        MicroChannel,

        /// <summary>
        ///     The turbo channel
        /// </summary>
        TurboChannel,

        /// <summary>
        ///     The pci bus
        /// </summary>
        PCIBus,

        /// <summary>
        ///     The vme bus
        /// </summary>
        VMEBus,

        /// <summary>
        ///     The nu bus
        /// </summary>
        NuBus,

        /// <summary>
        ///     The pcmcia bus
        /// </summary>
        PCMCIABus,

        /// <summary>
        ///     The c bus
        /// </summary>
        CBus,

        /// <summary>
        ///     The mpi bus
        /// </summary>
        MPIBus,

        /// <summary>
        ///     The mpsa bus
        /// </summary>
        MPSABus,

        /// <summary>
        ///     The processor internal
        /// </summary>
        ProcessorInternal,

        /// <summary>
        ///     The internal power bus
        /// </summary>
        InternalPowerBus,

        /// <summary>
        ///     The pnpisa bus
        /// </summary>
        PNPISABus,

        /// <summary>
        ///     The PNP bus
        /// </summary>
        PNPBus,

        /// <summary>
        ///     The VMCS
        /// </summary>
        Vmcs,

        /// <summary>
        ///     The maximum interface type
        /// </summary>
        MaximumInterfaceType
    }

    /// <summary>
    ///     Enum BUS_DATA_TYPE
    /// </summary>
    public enum BUS_DATA_TYPE
    {
        /// <summary>
        ///     The configuration space undefined
        /// </summary>
        ConfigurationSpaceUndefined = -1,

        /// <summary>
        ///     The cmos
        /// </summary>
        Cmos,

        /// <summary>
        ///     The eisa configuration
        /// </summary>
        EisaConfiguration,

        /// <summary>
        ///     The position
        /// </summary>
        Pos,

        /// <summary>
        ///     The cbus configuration
        /// </summary>
        CbusConfiguration,

        /// <summary>
        ///     The pci configuration
        /// </summary>
        PCIConfiguration,

        /// <summary>
        ///     The vme configuration
        /// </summary>
        VMEConfiguration,

        /// <summary>
        ///     The nu bus configuration
        /// </summary>
        NuBusConfiguration,

        /// <summary>
        ///     The pcmcia configuration
        /// </summary>
        PCMCIAConfiguration,

        /// <summary>
        ///     The mpi configuration
        /// </summary>
        MPIConfiguration,

        /// <summary>
        ///     The mpsa configuration
        /// </summary>
        MPSAConfiguration,

        /// <summary>
        ///     The pnpisa configuration
        /// </summary>
        PNPISAConfiguration,

        /// <summary>
        ///     The sgi internal configuration
        /// </summary>
        SgiInternalConfiguration,

        /// <summary>
        ///     The maximum bus data type
        /// </summary>
        MaximumBusDataType
    }

    /// <summary>
    ///     Enum DEBUG_DATA
    /// </summary>
    public enum DEBUG_DATA : uint
    {
        /// <summary>
        ///     The KPCR offset
        /// </summary>
        KPCR_OFFSET = 0,

        /// <summary>
        ///     The KPRCB offset
        /// </summary>
        KPRCB_OFFSET = 1,

        /// <summary>
        ///     The kthread offset
        /// </summary>
        KTHREAD_OFFSET = 2,

        /// <summary>
        ///     The base translation virtual offset
        /// </summary>
        BASE_TRANSLATION_VIRTUAL_OFFSET = 3,

        /// <summary>
        ///     The processor identification
        /// </summary>
        PROCESSOR_IDENTIFICATION = 4,

        /// <summary>
        ///     The processor speed
        /// </summary>
        PROCESSOR_SPEED = 5
    }

    /// <summary>
    ///     Enum DEBUG_MODULE
    /// </summary>
    [Flags]
    public enum DEBUG_MODULE : uint
    {
        /// <summary>
        ///     The loaded
        /// </summary>
        LOADED = 0,

        /// <summary>
        ///     The unloaded
        /// </summary>
        UNLOADED = 1,

        /// <summary>
        ///     The user mode
        /// </summary>
        USER_MODE = 2,

        /// <summary>
        ///     The executable module
        /// </summary>
        EXE_MODULE = 4,

        /// <summary>
        ///     The explicit
        /// </summary>
        EXPLICIT = 8,

        /// <summary>
        ///     The secondary
        /// </summary>
        SECONDARY = 0x10,

        /// <summary>
        ///     The synthetic
        /// </summary>
        SYNTHETIC = 0x20,

        /// <summary>
        ///     The sym bad checksum
        /// </summary>
        SYM_BAD_CHECKSUM = 0x10000
    }

    /// <summary>
    ///     Enum DEBUG_SYMTYPE
    /// </summary>
    public enum DEBUG_SYMTYPE : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     The coff
        /// </summary>
        COFF = 1,

        /// <summary>
        ///     The codeview
        /// </summary>
        CODEVIEW = 2,

        /// <summary>
        ///     The PDB
        /// </summary>
        PDB = 3,

        /// <summary>
        ///     The export
        /// </summary>
        EXPORT = 4,

        /// <summary>
        ///     The deferred
        /// </summary>
        DEFERRED = 5,

        /// <summary>
        ///     The sym
        /// </summary>
        SYM = 6,

        /// <summary>
        ///     The dia
        /// </summary>
        DIA = 7
    }

    /// <summary>
    ///     Enum DEBUG_OUTTYPE
    /// </summary>
    [Flags]
    public enum DEBUG_OUTTYPE
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no indent
        /// </summary>
        NO_INDENT = 1,

        /// <summary>
        ///     The no offset
        /// </summary>
        NO_OFFSET = 2,

        /// <summary>
        ///     The verbose
        /// </summary>
        VERBOSE = 4,

        /// <summary>
        ///     The compact output
        /// </summary>
        COMPACT_OUTPUT = 8,

        /// <summary>
        ///     The address of field
        /// </summary>
        ADDRESS_OF_FIELD = 0x10000,

        /// <summary>
        ///     The address ant end
        /// </summary>
        ADDRESS_ANT_END = 0x20000,

        /// <summary>
        ///     The block recurse
        /// </summary>
        BLOCK_RECURSE = 0x200000
    }

    /// <summary>
    ///     Enum DEBUG_SCOPE_GROUP
    /// </summary>
    [Flags]
    public enum DEBUG_SCOPE_GROUP : uint
    {
        /// <summary>
        ///     The arguments
        /// </summary>
        ARGUMENTS = 1,

        /// <summary>
        ///     The locals
        /// </summary>
        LOCALS = 2,

        /// <summary>
        ///     All
        /// </summary>
        ALL = 3
    }

    /// <summary>
    ///     Enum DEBUG_FIND_SOURCE
    /// </summary>
    [Flags]
    public enum DEBUG_FIND_SOURCE : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The full path
        /// </summary>
        FULL_PATH = 1,

        /// <summary>
        ///     The best match
        /// </summary>
        BEST_MATCH = 2,

        /// <summary>
        ///     The no SRCSRV
        /// </summary>
        NO_SRCSRV = 4,

        /// <summary>
        ///     The token lookup
        /// </summary>
        TOKEN_LOOKUP = 8
    }

    /// <summary>
    ///     Enum MODULE_ORDERS
    /// </summary>
    [Flags]
    public enum MODULE_ORDERS : uint
    {
        /// <summary>
        ///     The mask
        /// </summary>
        MASK = 0xF0000000,

        /// <summary>
        ///     The loadtime
        /// </summary>
        LOADTIME = 0x10000000,

        /// <summary>
        ///     The modulename
        /// </summary>
        MODULENAME = 0x20000000
    }

    /// <summary>
    ///     Enum SYMOPT
    /// </summary>
    [Flags]
    public enum SYMOPT : uint
    {
        /// <summary>
        ///     The case insensitive
        /// </summary>
        CASE_INSENSITIVE = 0x00000001,

        /// <summary>
        ///     The undname
        /// </summary>
        UNDNAME = 0x00000002,

        /// <summary>
        ///     The deferred loads
        /// </summary>
        DEFERRED_LOADS = 0x00000004,

        /// <summary>
        ///     The no CPP
        /// </summary>
        NO_CPP = 0x00000008,

        /// <summary>
        ///     The load lines
        /// </summary>
        LOAD_LINES = 0x00000010,

        /// <summary>
        ///     The omap find nearest
        /// </summary>
        OMAP_FIND_NEAREST = 0x00000020,

        /// <summary>
        ///     The load anything
        /// </summary>
        LOAD_ANYTHING = 0x00000040,

        /// <summary>
        ///     The ignore cvrec
        /// </summary>
        IGNORE_CVREC = 0x00000080,

        /// <summary>
        ///     The no unqualified loads
        /// </summary>
        NO_UNQUALIFIED_LOADS = 0x00000100,

        /// <summary>
        ///     The fail critical errors
        /// </summary>
        FAIL_CRITICAL_ERRORS = 0x00000200,

        /// <summary>
        ///     The exact symbols
        /// </summary>
        EXACT_SYMBOLS = 0x00000400,

        /// <summary>
        ///     The allow absolute symbols
        /// </summary>
        ALLOW_ABSOLUTE_SYMBOLS = 0x00000800,

        /// <summary>
        ///     The ignore nt sympath
        /// </summary>
        IGNORE_NT_SYMPATH = 0x00001000,

        /// <summary>
        ///     The include 32 bit modules
        /// </summary>
        INCLUDE_32BIT_MODULES = 0x00002000,

        /// <summary>
        ///     The publics only
        /// </summary>
        PUBLICS_ONLY = 0x00004000,

        /// <summary>
        ///     The no publics
        /// </summary>
        NO_PUBLICS = 0x00008000,

        /// <summary>
        ///     The automatic publics
        /// </summary>
        AUTO_PUBLICS = 0x00010000,

        /// <summary>
        ///     The no image search
        /// </summary>
        NO_IMAGE_SEARCH = 0x00020000,

        /// <summary>
        ///     The secure
        /// </summary>
        SECURE = 0x00040000,

        /// <summary>
        ///     The no prompts
        /// </summary>
        NO_PROMPTS = 0x00080000,

        /// <summary>
        ///     The overwrite
        /// </summary>
        OVERWRITE = 0x00100000,

        /// <summary>
        ///     The ignore imagedir
        /// </summary>
        IGNORE_IMAGEDIR = 0x00200000,

        /// <summary>
        ///     The flat directory
        /// </summary>
        FLAT_DIRECTORY = 0x00400000,

        /// <summary>
        ///     The favor compressed
        /// </summary>
        FAVOR_COMPRESSED = 0x00800000,

        /// <summary>
        ///     The allow zero address
        /// </summary>
        ALLOW_ZERO_ADDRESS = 0x01000000,

        /// <summary>
        ///     The disable symsrv autodetect
        /// </summary>
        DISABLE_SYMSRV_AUTODETECT = 0x02000000,

        /// <summary>
        ///     The debug
        /// </summary>
        DEBUG = 0x80000000
    }

    /// <summary>
    ///     Enum DEBUG_TYPEOPTS
    /// </summary>
    [Flags]
    public enum DEBUG_TYPEOPTS : uint
    {
        /// <summary>
        ///     The unicode display
        /// </summary>
        UNICODE_DISPLAY = 1,

        /// <summary>
        ///     The longstatus display
        /// </summary>
        LONGSTATUS_DISPLAY = 2,

        /// <summary>
        ///     The forceradix output
        /// </summary>
        FORCERADIX_OUTPUT = 4,

        /// <summary>
        ///     The match maxsize
        /// </summary>
        MATCH_MAXSIZE = 8
    }

    /// <summary>
    ///     Enum DEBUG_SYMBOL
    /// </summary>
    [Flags]
    public enum DEBUG_SYMBOL : uint
    {
        /// <summary>
        ///     The expansion level mask
        /// </summary>
        EXPANSION_LEVEL_MASK = 0xf,

        /// <summary>
        ///     The expanded
        /// </summary>
        EXPANDED = 0x10,

        /// <summary>
        ///     The read only
        /// </summary>
        READ_ONLY = 0x20,

        /// <summary>
        ///     The is array
        /// </summary>
        IS_ARRAY = 0x40,

        /// <summary>
        ///     The is float
        /// </summary>
        IS_FLOAT = 0x80,

        /// <summary>
        ///     The is argument
        /// </summary>
        IS_ARGUMENT = 0x100,

        /// <summary>
        ///     The is local
        /// </summary>
        IS_LOCAL = 0x200
    }

    /// <summary>
    ///     Enum DEBUG_OUTPUT_SYMBOLS
    /// </summary>
    [Flags]
    public enum DEBUG_OUTPUT_SYMBOLS
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no names
        /// </summary>
        NO_NAMES = 1,

        /// <summary>
        ///     The no offsets
        /// </summary>
        NO_OFFSETS = 2,

        /// <summary>
        ///     The no values
        /// </summary>
        NO_VALUES = 4,

        /// <summary>
        ///     The no types
        /// </summary>
        NO_TYPES = 0x10
    }

    /// <summary>
    ///     Enum DEBUG_INTERRUPT
    /// </summary>
    public enum DEBUG_INTERRUPT : uint
    {
        /// <summary>
        ///     The active
        /// </summary>
        ACTIVE = 0,

        /// <summary>
        ///     The passive
        /// </summary>
        PASSIVE = 1,

        /// <summary>
        ///     The exit
        /// </summary>
        EXIT = 2
    }

    /// <summary>
    ///     Enum DEBUG_CURRENT
    /// </summary>
    [Flags]
    public enum DEBUG_CURRENT : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0xf,

        /// <summary>
        ///     The symbol
        /// </summary>
        SYMBOL = 1,

        /// <summary>
        ///     The disasm
        /// </summary>
        DISASM = 2,

        /// <summary>
        ///     The registers
        /// </summary>
        REGISTERS = 4,

        /// <summary>
        ///     The source line
        /// </summary>
        SOURCE_LINE = 8
    }

    /// <summary>
    ///     Enum DEBUG_DISASM
    /// </summary>
    [Flags]
    public enum DEBUG_DISASM : uint
    {
        /// <summary>
        ///     The effective address
        /// </summary>
        EFFECTIVE_ADDRESS = 1,

        /// <summary>
        ///     The matching symbols
        /// </summary>
        MATCHING_SYMBOLS = 2,

        /// <summary>
        ///     The source line number
        /// </summary>
        SOURCE_LINE_NUMBER = 4,

        /// <summary>
        ///     The source file name
        /// </summary>
        SOURCE_FILE_NAME = 8
    }

    /// <summary>
    ///     Enum DEBUG_STACK
    /// </summary>
    [Flags]
    public enum DEBUG_STACK : uint
    {
        /// <summary>
        ///     The arguments
        /// </summary>
        ARGUMENTS = 0x1,

        /// <summary>
        ///     The function information
        /// </summary>
        FUNCTION_INFO = 0x2,

        /// <summary>
        ///     The source line
        /// </summary>
        SOURCE_LINE = 0x4,

        /// <summary>
        ///     The frame addresses
        /// </summary>
        FRAME_ADDRESSES = 0x8,

        /// <summary>
        ///     The column names
        /// </summary>
        COLUMN_NAMES = 0x10,

        /// <summary>
        ///     The nonvolatile registers
        /// </summary>
        NONVOLATILE_REGISTERS = 0x20,

        /// <summary>
        ///     The frame numbers
        /// </summary>
        FRAME_NUMBERS = 0x40,

        /// <summary>
        ///     The parameters
        /// </summary>
        PARAMETERS = 0x80,

        /// <summary>
        ///     The frame addresses ra only
        /// </summary>
        FRAME_ADDRESSES_RA_ONLY = 0x100,

        /// <summary>
        ///     The frame memory usage
        /// </summary>
        FRAME_MEMORY_USAGE = 0x200,

        /// <summary>
        ///     The parameters newline
        /// </summary>
        PARAMETERS_NEWLINE = 0x400,

        /// <summary>
        ///     The DML
        /// </summary>
        DML = 0x800,

        /// <summary>
        ///     The frame offsets
        /// </summary>
        FRAME_OFFSETS = 0x1000
    }

    /// <summary>
    ///     Enum IMAGE_FILE_MACHINE
    /// </summary>
    public enum IMAGE_FILE_MACHINE : uint
    {
        /// <summary>
        ///     The unknown
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        ///     The i386
        /// </summary>
        I386 = 0x014c, // Intel 386.

        /// <summary>
        ///     The R3000
        /// </summary>
        R3000 = 0x0162, // MIPS little-endian, 0x160 big-endian

        /// <summary>
        ///     The R4000
        /// </summary>
        R4000 = 0x0166, // MIPS little-endian

        /// <summary>
        ///     The R10000
        /// </summary>
        R10000 = 0x0168, // MIPS little-endian

        /// <summary>
        ///     The wcemips v2
        /// </summary>
        WCEMIPSV2 = 0x0169, // MIPS little-endian WCE v2

        /// <summary>
        ///     The alpha
        /// </summary>
        ALPHA = 0x0184, // Alpha_AXP

        /// <summary>
        ///     The s h3
        /// </summary>
        SH3 = 0x01a2, // SH3 little-endian

        /// <summary>
        ///     The s h3 DSP
        /// </summary>
        SH3DSP = 0x01a3,

        /// <summary>
        ///     The s h3 e
        /// </summary>
        SH3E = 0x01a4, // SH3E little-endian

        /// <summary>
        ///     The s h4
        /// </summary>
        SH4 = 0x01a6, // SH4 little-endian

        /// <summary>
        ///     The s h5
        /// </summary>
        SH5 = 0x01a8, // SH5

        /// <summary>
        ///     The arm
        /// </summary>
        ARM = 0x01c0, // ARM Little-Endian

        /// <summary>
        ///     The thumb
        /// </summary>
        THUMB = 0x01c2,

        /// <summary>
        ///     The thum b2
        /// </summary>
        THUMB2 = 0x1c4,

        /// <summary>
        ///     a M33
        /// </summary>
        AM33 = 0x01d3,

        /// <summary>
        ///     The powerpc
        /// </summary>
        POWERPC = 0x01F0, // IBM PowerPC Little-Endian

        /// <summary>
        ///     The powerpcfp
        /// </summary>
        POWERPCFP = 0x01f1,

        /// <summary>
        ///     The i a64
        /// </summary>
        IA64 = 0x0200, // Intel 64

        /// <summary>
        ///     The mip S16
        /// </summary>
        MIPS16 = 0x0266, // MIPS

        /// <summary>
        ///     The alph a64
        /// </summary>
        ALPHA64 = 0x0284, // ALPHA64

        /// <summary>
        ///     The mipsfpu
        /// </summary>
        MIPSFPU = 0x0366, // MIPS

        /// <summary>
        ///     The mipsfp u16
        /// </summary>
        MIPSFPU16 = 0x0466, // MIPS

        /// <summary>
        ///     The ax P64
        /// </summary>
        AXP64 = 0x0284,

        /// <summary>
        ///     The tricore
        /// </summary>
        TRICORE = 0x0520, // Infineon

        /// <summary>
        ///     The cef
        /// </summary>
        CEF = 0x0CEF,

        /// <summary>
        ///     The ebc
        /// </summary>
        EBC = 0x0EBC, // EFI Byte Code

        /// <summary>
        ///     The am D64
        /// </summary>
        AMD64 = 0x8664, // AMD64 (K8)

        /// <summary>
        ///     The M32 r
        /// </summary>
        M32R = 0x9041, // M32R little-endian

        /// <summary>
        ///     The cee
        /// </summary>
        CEE = 0xC0EE
    }

    /// <summary>
    ///     Enum DEBUG_STATUS
    /// </summary>
    public enum DEBUG_STATUS : uint
    {
        /// <summary>
        ///     The no change
        /// </summary>
        NO_CHANGE = 0,

        /// <summary>
        ///     The go
        /// </summary>
        GO = 1,

        /// <summary>
        ///     The go handled
        /// </summary>
        GO_HANDLED = 2,

        /// <summary>
        ///     The go not handled
        /// </summary>
        GO_NOT_HANDLED = 3,

        /// <summary>
        ///     The step over
        /// </summary>
        STEP_OVER = 4,

        /// <summary>
        ///     The step into
        /// </summary>
        STEP_INTO = 5,

        /// <summary>
        ///     The break
        /// </summary>
        BREAK = 6,

        /// <summary>
        ///     The no debuggee
        /// </summary>
        NO_DEBUGGEE = 7,

        /// <summary>
        ///     The step branch
        /// </summary>
        STEP_BRANCH = 8,

        /// <summary>
        ///     The ignore event
        /// </summary>
        IGNORE_EVENT = 9,

        /// <summary>
        ///     The restart requested
        /// </summary>
        RESTART_REQUESTED = 10,

        /// <summary>
        ///     The reverse go
        /// </summary>
        REVERSE_GO = 11,

        /// <summary>
        ///     The reverse step branch
        /// </summary>
        REVERSE_STEP_BRANCH = 12,

        /// <summary>
        ///     The reverse step over
        /// </summary>
        REVERSE_STEP_OVER = 13,

        /// <summary>
        ///     The reverse step into
        /// </summary>
        REVERSE_STEP_INTO = 14,

        /// <summary>
        ///     The out of synchronize
        /// </summary>
        OUT_OF_SYNC = 15,

        /// <summary>
        ///     The wait input
        /// </summary>
        WAIT_INPUT = 16,

        /// <summary>
        ///     The timeout
        /// </summary>
        TIMEOUT = 17,

        /// <summary>
        ///     The mask
        /// </summary>
        MASK = 0x1f
    }

    /// <summary>
    ///     Enum DEBUG_STATUS_FLAGS
    /// </summary>
    public enum DEBUG_STATUS_FLAGS : ulong
    {
        /// <summary>
        ///     This bit is added in DEBUG_CES_EXECUTION_STATUS notifications when the
        ///     engines execution status is changing due to operations performed during a
        ///     wait, such as making synchronous callbacks. If the bit is not set the
        ///     execution status is changing due to a wait being satisfied.
        /// </summary>
        /// <summary>
        ///     The inside wait
        /// </summary>
        INSIDE_WAIT = 0x100000000,

        /// <summary>
        ///     This bit is added in DEBUG_CES_EXECUTION_STATUS notifications when the
        ///     engines execution status update is coming after a wait has timed-out. It
        ///     indicates that the execution status change was not due to an actual event.
        /// </summary>
        /// <summary>
        ///     The wait timeout
        /// </summary>
        WAIT_TIMEOUT = 0x200000000
    }

    /// <summary>
    ///     Enum DEBUG_CES_EXECUTION_STATUS
    /// </summary>
    [Flags]
    public enum DEBUG_CES_EXECUTION_STATUS : ulong
    {
        /// <summary>
        ///     The inside wait
        /// </summary>
        INSIDE_WAIT = 0x100000000UL,

        /// <summary>
        ///     The wait timeout
        /// </summary>
        WAIT_TIMEOUT = 0x200000000UL
    }

    /// <summary>
    ///     Enum DEBUG_LEVEL
    /// </summary>
    public enum DEBUG_LEVEL : uint
    {
        /// <summary>
        ///     The source
        /// </summary>
        SOURCE = 0,

        /// <summary>
        ///     The assembly
        /// </summary>
        ASSEMBLY = 1
    }

    /// <summary>
    ///     Enum DEBUG_ENGOPT
    /// </summary>
    [Flags]
    public enum DEBUG_ENGOPT : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     The ignore dbghelp version
        /// </summary>
        IGNORE_DBGHELP_VERSION = 0x00000001,

        /// <summary>
        ///     The ignore extension versions
        /// </summary>
        IGNORE_EXTENSION_VERSIONS = 0x00000002,

        /// <summary>
        ///     The allow network paths
        /// </summary>
        ALLOW_NETWORK_PATHS = 0x00000004,

        /// <summary>
        ///     The disallow network paths
        /// </summary>
        DISALLOW_NETWORK_PATHS = 0x00000008,

        /// <summary>
        ///     The network paths
        /// </summary>
        NETWORK_PATHS = 0x00000004 | 0x00000008,

        /// <summary>
        ///     The ignore loader exceptions
        /// </summary>
        IGNORE_LOADER_EXCEPTIONS = 0x00000010,

        /// <summary>
        ///     The initial break
        /// </summary>
        INITIAL_BREAK = 0x00000020,

        /// <summary>
        ///     The initial module break
        /// </summary>
        INITIAL_MODULE_BREAK = 0x00000040,

        /// <summary>
        ///     The final break
        /// </summary>
        FINAL_BREAK = 0x00000080,

        /// <summary>
        ///     The no execute repeat
        /// </summary>
        NO_EXECUTE_REPEAT = 0x00000100,

        /// <summary>
        ///     The fail incomplete information
        /// </summary>
        FAIL_INCOMPLETE_INFORMATION = 0x00000200,

        /// <summary>
        ///     The allow read only breakpoints
        /// </summary>
        ALLOW_READ_ONLY_BREAKPOINTS = 0x00000400,

        /// <summary>
        ///     The synchronize breakpoints
        /// </summary>
        SYNCHRONIZE_BREAKPOINTS = 0x00000800,

        /// <summary>
        ///     The disallow shell commands
        /// </summary>
        DISALLOW_SHELL_COMMANDS = 0x00001000,

        /// <summary>
        ///     The kd quiet mode
        /// </summary>
        KD_QUIET_MODE = 0x00002000,

        /// <summary>
        ///     The disable managed support
        /// </summary>
        DISABLE_MANAGED_SUPPORT = 0x00004000,

        /// <summary>
        ///     The disable module symbol load
        /// </summary>
        DISABLE_MODULE_SYMBOL_LOAD = 0x00008000,

        /// <summary>
        ///     The disable execution commands
        /// </summary>
        DISABLE_EXECUTION_COMMANDS = 0x00010000,

        /// <summary>
        ///     The disallow image file mapping
        /// </summary>
        DISALLOW_IMAGE_FILE_MAPPING = 0x00020000,

        /// <summary>
        ///     The prefer DML
        /// </summary>
        PREFER_DML = 0x00040000,

        /// <summary>
        ///     All
        /// </summary>
        ALL = 0x0007FFFF
    }

    /// <summary>
    ///     Enum ERROR_LEVEL
    /// </summary>
    public enum ERROR_LEVEL
    {
        /// <summary>
        ///     The error
        /// </summary>
        ERROR = 1,

        /// <summary>
        ///     The minorerror
        /// </summary>
        MINORERROR = 2,

        /// <summary>
        ///     The warning
        /// </summary>
        WARNING = 3
    }

    /// <summary>
    ///     Enum DEBUG_EXECUTE
    /// </summary>
    [Flags]
    public enum DEBUG_EXECUTE : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The echo
        /// </summary>
        ECHO = 1,

        /// <summary>
        ///     The not logged
        /// </summary>
        NOT_LOGGED = 2,

        /// <summary>
        ///     The no repeat
        /// </summary>
        NO_REPEAT = 4
    }

    /// <summary>
    ///     Enum DEBUG_FILTER_EVENT
    /// </summary>
    public enum DEBUG_FILTER_EVENT : uint
    {
        /// <summary>
        ///     The create thread
        /// </summary>
        CREATE_THREAD = 0x00000000,

        /// <summary>
        ///     The exit thread
        /// </summary>
        EXIT_THREAD = 0x00000001,

        /// <summary>
        ///     The create process
        /// </summary>
        CREATE_PROCESS = 0x00000002,

        /// <summary>
        ///     The exit process
        /// </summary>
        EXIT_PROCESS = 0x00000003,

        /// <summary>
        ///     The load module
        /// </summary>
        LOAD_MODULE = 0x00000004,

        /// <summary>
        ///     The unload module
        /// </summary>
        UNLOAD_MODULE = 0x00000005,

        /// <summary>
        ///     The system error
        /// </summary>
        SYSTEM_ERROR = 0x00000006,

        /// <summary>
        ///     The initial breakpoint
        /// </summary>
        INITIAL_BREAKPOINT = 0x00000007,

        /// <summary>
        ///     The initial module load
        /// </summary>
        INITIAL_MODULE_LOAD = 0x00000008,

        /// <summary>
        ///     The debuggee output
        /// </summary>
        DEBUGGEE_OUTPUT = 0x00000009
    }

    /// <summary>
    ///     Enum DEBUG_FILTER_EXEC_OPTION
    /// </summary>
    public enum DEBUG_FILTER_EXEC_OPTION : uint
    {
        /// <summary>
        ///     The break
        /// </summary>
        BREAK = 0x00000000,

        /// <summary>
        ///     The second chance break
        /// </summary>
        SECOND_CHANCE_BREAK = 0x00000001,

        /// <summary>
        ///     The output
        /// </summary>
        OUTPUT = 0x00000002,

        /// <summary>
        ///     The ignore
        /// </summary>
        IGNORE = 0x00000003,

        /// <summary>
        ///     The remove
        /// </summary>
        REMOVE = 0x00000004
    }

    /// <summary>
    ///     Enum DEBUG_FILTER_CONTINUE_OPTION
    /// </summary>
    public enum DEBUG_FILTER_CONTINUE_OPTION : uint
    {
        /// <summary>
        ///     The go handled
        /// </summary>
        GO_HANDLED = 0x00000000,

        /// <summary>
        ///     The go not handled
        /// </summary>
        GO_NOT_HANDLED = 0x00000001
    }

    /// <summary>
    ///     Enum DEBUG_WAIT
    /// </summary>
    [Flags]
    public enum DEBUG_WAIT : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0
    }

    /// <summary>
    ///     Enum DEBUG_HANDLE_DATA_TYPE
    /// </summary>
    public enum DEBUG_HANDLE_DATA_TYPE : uint
    {
        /// <summary>
        ///     The basic
        /// </summary>
        BASIC = 0,

        /// <summary>
        ///     The type name
        /// </summary>
        TYPE_NAME = 1,

        /// <summary>
        ///     The object name
        /// </summary>
        OBJECT_NAME = 2,

        /// <summary>
        ///     The handle count
        /// </summary>
        HANDLE_COUNT = 3,

        /// <summary>
        ///     The type name wide
        /// </summary>
        TYPE_NAME_WIDE = 4,

        /// <summary>
        ///     The object name wide
        /// </summary>
        OBJECT_NAME_WIDE = 5,

        /// <summary>
        ///     The mini thread 1
        /// </summary>
        MINI_THREAD_1 = 6,

        /// <summary>
        ///     The mini mutant 1
        /// </summary>
        MINI_MUTANT_1 = 7,

        /// <summary>
        ///     The mini mutant 2
        /// </summary>
        MINI_MUTANT_2 = 8,

        /// <summary>
        ///     The per handle operations
        /// </summary>
        PER_HANDLE_OPERATIONS = 9,

        /// <summary>
        ///     All handle operations
        /// </summary>
        ALL_HANDLE_OPERATIONS = 10,

        /// <summary>
        ///     The mini process 1
        /// </summary>
        MINI_PROCESS_1 = 11,

        /// <summary>
        ///     The mini process 2
        /// </summary>
        MINI_PROCESS_2 = 12
    }

    /// <summary>
    ///     Enum DEBUG_DATA_SPACE
    /// </summary>
    public enum DEBUG_DATA_SPACE : uint
    {
        /// <summary>
        ///     The virtual
        /// </summary>
        VIRTUAL = 0,

        /// <summary>
        ///     The physical
        /// </summary>
        PHYSICAL = 1,

        /// <summary>
        ///     The control
        /// </summary>
        CONTROL = 2,

        /// <summary>
        ///     The io
        /// </summary>
        IO = 3,

        /// <summary>
        ///     The MSR
        /// </summary>
        MSR = 4,

        /// <summary>
        ///     The bus data
        /// </summary>
        BUS_DATA = 5,

        /// <summary>
        ///     The debugger data
        /// </summary>
        DEBUGGER_DATA = 6
    }

    /// <summary>
    ///     Enum DEBUG_OFFSINFO
    /// </summary>
    public enum DEBUG_OFFSINFO : uint
    {
        /// <summary>
        ///     The virtual source
        /// </summary>
        VIRTUAL_SOURCE = 0x00000001
    }

    /// <summary>
    ///     Enum DEBUG_VSOURCE
    /// </summary>
    public enum DEBUG_VSOURCE : uint
    {
        /// <summary>
        ///     The invalid
        /// </summary>
        INVALID = 0,

        /// <summary>
        ///     The debuggee
        /// </summary>
        DEBUGGEE = 1,

        /// <summary>
        ///     The mapped image
        /// </summary>
        MAPPED_IMAGE = 2,

        /// <summary>
        ///     The dump without meminfo
        /// </summary>
        DUMP_WITHOUT_MEMINFO = 3
    }

    /// <summary>
    ///     Enum DEBUG_VSEARCH
    /// </summary>
    public enum DEBUG_VSEARCH : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The writable only
        /// </summary>
        WRITABLE_ONLY = 1
    }

    /// <summary>
    ///     Enum CODE_PAGE
    /// </summary>
    public enum CODE_PAGE : uint
    {
        /// <summary>
        ///     The acp
        /// </summary>
        ACP = 0, // default to ANSI code page

        /// <summary>
        ///     The oemcp
        /// </summary>
        OEMCP = 1, // default to OEM  code page

        /// <summary>
        ///     The maccp
        /// </summary>
        MACCP = 2, // default to MAC  code page

        /// <summary>
        ///     The thread acp
        /// </summary>
        THREAD_ACP = 3, // current thread's ANSI code page

        /// <summary>
        ///     The symbol
        /// </summary>
        SYMBOL = 42, // SYMBOL translations

        /// <summary>
        ///     The ut f7
        /// </summary>
        UTF7 = 65000, // UTF-7 translation

        /// <summary>
        ///     The ut f8
        /// </summary>
        UTF8 = 65001 // UTF-8 translation
    }

    /// <summary>
    ///     Enum DEBUG_PHYSICAL
    /// </summary>
    public enum DEBUG_PHYSICAL : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The cached
        /// </summary>
        CACHED = 1,

        /// <summary>
        ///     The uncached
        /// </summary>
        UNCACHED = 2,

        /// <summary>
        ///     The write combined
        /// </summary>
        WRITE_COMBINED = 3
    }

    /// <summary>
    ///     Enum DEBUG_OUTCBI
    /// </summary>
    [Flags]
    public enum DEBUG_OUTCBI : uint
    {
        /// <summary>
        ///     The explicit flush
        /// </summary>
        EXPLICIT_FLUSH = 1,

        /// <summary>
        ///     The text
        /// </summary>
        TEXT = 2,

        /// <summary>
        ///     The DML
        /// </summary>
        DML = 4,

        /// <summary>
        ///     Any format
        /// </summary>
        ANY_FORMAT = 6
    }

    /// <summary>
    ///     Enum DEBUG_OUTCB
    /// </summary>
    public enum DEBUG_OUTCB : uint
    {
        /// <summary>
        ///     The text
        /// </summary>
        TEXT = 0,

        /// <summary>
        ///     The DML
        /// </summary>
        DML = 1,

        /// <summary>
        ///     The explicit flush
        /// </summary>
        EXPLICIT_FLUSH = 2
    }

    /// <summary>
    ///     Enum DEBUG_OUTCBF
    /// </summary>
    [Flags]
    public enum DEBUG_OUTCBF : uint
    {
        /// <summary>
        ///     The explicit flush
        /// </summary>
        EXPLICIT_FLUSH = 1,

        /// <summary>
        ///     The DML has tags
        /// </summary>
        DML_HAS_TAGS = 2,

        /// <summary>
        ///     The DML has special characters
        /// </summary>
        DML_HAS_SPECIAL_CHARACTERS = 4
    }

    /// <summary>
    ///     Enum DEBUG_FORMAT
    /// </summary>
    [Flags]
    public enum DEBUG_FORMAT : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0x00000000,

        /// <summary>
        ///     The CAB secondary all images
        /// </summary>
        CAB_SECONDARY_ALL_IMAGES = 0x10000000,

        /// <summary>
        ///     The write CAB
        /// </summary>
        WRITE_CAB = 0x20000000,

        /// <summary>
        ///     The CAB secondary files
        /// </summary>
        CAB_SECONDARY_FILES = 0x40000000,

        /// <summary>
        ///     The no overwrite
        /// </summary>
        NO_OVERWRITE = 0x80000000,

        /// <summary>
        ///     The user small full memory
        /// </summary>
        USER_SMALL_FULL_MEMORY = 0x00000001,

        /// <summary>
        ///     The user small handle data
        /// </summary>
        USER_SMALL_HANDLE_DATA = 0x00000002,

        /// <summary>
        ///     The user small unloaded modules
        /// </summary>
        USER_SMALL_UNLOADED_MODULES = 0x00000004,

        /// <summary>
        ///     The user small indirect memory
        /// </summary>
        USER_SMALL_INDIRECT_MEMORY = 0x00000008,

        /// <summary>
        ///     The user small data segments
        /// </summary>
        USER_SMALL_DATA_SEGMENTS = 0x00000010,

        /// <summary>
        ///     The user small filter memory
        /// </summary>
        USER_SMALL_FILTER_MEMORY = 0x00000020,

        /// <summary>
        ///     The user small filter paths
        /// </summary>
        USER_SMALL_FILTER_PATHS = 0x00000040,

        /// <summary>
        ///     The user small process thread data
        /// </summary>
        USER_SMALL_PROCESS_THREAD_DATA = 0x00000080,

        /// <summary>
        ///     The user small private read write memory
        /// </summary>
        USER_SMALL_PRIVATE_READ_WRITE_MEMORY = 0x00000100,

        /// <summary>
        ///     The user small no optional data
        /// </summary>
        USER_SMALL_NO_OPTIONAL_DATA = 0x00000200,

        /// <summary>
        ///     The user small full memory information
        /// </summary>
        USER_SMALL_FULL_MEMORY_INFO = 0x00000400,

        /// <summary>
        ///     The user small thread information
        /// </summary>
        USER_SMALL_THREAD_INFO = 0x00000800,

        /// <summary>
        ///     The user small code segments
        /// </summary>
        USER_SMALL_CODE_SEGMENTS = 0x00001000,

        /// <summary>
        ///     The user small no auxiliary state
        /// </summary>
        USER_SMALL_NO_AUXILIARY_STATE = 0x00002000,

        /// <summary>
        ///     The user small full auxiliary state
        /// </summary>
        USER_SMALL_FULL_AUXILIARY_STATE = 0x00004000,

        /// <summary>
        ///     The user small ignore inaccessible memory
        /// </summary>
        USER_SMALL_IGNORE_INACCESSIBLE_MEM = 0x08000000
    }

    /// <summary>
    ///     Enum DEBUG_DUMP_FILE
    /// </summary>
    public enum DEBUG_DUMP_FILE : uint
    {
        /// <summary>
        ///     The base
        /// </summary>
        BASE = 0xffffffff,

        /// <summary>
        ///     The page file dump
        /// </summary>
        PAGE_FILE_DUMP = 0
    }

    /// <summary>
    ///     Enum MEM
    /// </summary>
    [Flags]
    public enum MEM : uint
    {
        /// <summary>
        ///     The commit
        /// </summary>
        COMMIT = 0x1000,

        /// <summary>
        ///     The reserve
        /// </summary>
        RESERVE = 0x2000,

        /// <summary>
        ///     The decommit
        /// </summary>
        DECOMMIT = 0x4000,

        /// <summary>
        ///     The release
        /// </summary>
        RELEASE = 0x8000,

        /// <summary>
        ///     The free
        /// </summary>
        FREE = 0x10000,

        /// <summary>
        ///     The private
        /// </summary>
        PRIVATE = 0x20000,

        /// <summary>
        ///     The mapped
        /// </summary>
        MAPPED = 0x40000,

        /// <summary>
        ///     The reset
        /// </summary>
        RESET = 0x80000,

        /// <summary>
        ///     The top down
        /// </summary>
        TOP_DOWN = 0x100000,

        /// <summary>
        ///     The write watch
        /// </summary>
        WRITE_WATCH = 0x200000,

        /// <summary>
        ///     The physical
        /// </summary>
        PHYSICAL = 0x400000,

        /// <summary>
        ///     The rotate
        /// </summary>
        ROTATE = 0x800000,

        /// <summary>
        ///     The large pages
        /// </summary>
        LARGE_PAGES = 0x20000000,

        /// <summary>
        ///     The fourmb pages
        /// </summary>
        FOURMB_PAGES = 0x80000000,

        /// <summary>
        ///     The image
        /// </summary>
        IMAGE = SEC.IMAGE
    }

    /// <summary>
    ///     Enum PAGE
    /// </summary>
    [Flags]
    public enum PAGE : uint
    {
        /// <summary>
        ///     The noaccess
        /// </summary>
        NOACCESS = 0x01,

        /// <summary>
        ///     The readonly
        /// </summary>
        READONLY = 0x02,

        /// <summary>
        ///     The readwrite
        /// </summary>
        READWRITE = 0x04,

        /// <summary>
        ///     The writecopy
        /// </summary>
        WRITECOPY = 0x08,

        /// <summary>
        ///     The execute
        /// </summary>
        EXECUTE = 0x10,

        /// <summary>
        ///     The execute read
        /// </summary>
        EXECUTE_READ = 0x20,

        /// <summary>
        ///     The execute readwrite
        /// </summary>
        EXECUTE_READWRITE = 0x40,

        /// <summary>
        ///     The execute writecopy
        /// </summary>
        EXECUTE_WRITECOPY = 0x80,

        /// <summary>
        ///     The guard
        /// </summary>
        GUARD = 0x100,

        /// <summary>
        ///     The nocache
        /// </summary>
        NOCACHE = 0x200,

        /// <summary>
        ///     The writecombine
        /// </summary>
        WRITECOMBINE = 0x400
    }

    /// <summary>
    ///     Enum SEC
    /// </summary>
    [Flags]
    public enum SEC : uint
    {
        /// <summary>
        ///     The file
        /// </summary>
        FILE = 0x800000,

        /// <summary>
        ///     The image
        /// </summary>
        IMAGE = 0x1000000,

        /// <summary>
        ///     The protected image
        /// </summary>
        PROTECTED_IMAGE = 0x2000000,

        /// <summary>
        ///     The reserve
        /// </summary>
        RESERVE = 0x4000000,

        /// <summary>
        ///     The commit
        /// </summary>
        COMMIT = 0x8000000,

        /// <summary>
        ///     The nocache
        /// </summary>
        NOCACHE = 0x10000000,

        /// <summary>
        ///     The writecombine
        /// </summary>
        WRITECOMBINE = 0x40000000,

        /// <summary>
        ///     The large pages
        /// </summary>
        LARGE_PAGES = 0x80000000,

        /// <summary>
        ///     The memory image
        /// </summary>
        MEM_IMAGE = IMAGE
    }

    /// <summary>
    ///     Enum DEBUG_MODNAME
    /// </summary>
    public enum DEBUG_MODNAME : uint
    {
        /// <summary>
        ///     The image
        /// </summary>
        IMAGE = 0x00000000,

        /// <summary>
        ///     The module
        /// </summary>
        MODULE = 0x00000001,

        /// <summary>
        ///     The loaded image
        /// </summary>
        LOADED_IMAGE = 0x00000002,

        /// <summary>
        ///     The symbol file
        /// </summary>
        SYMBOL_FILE = 0x00000003,

        /// <summary>
        ///     The mapped image
        /// </summary>
        MAPPED_IMAGE = 0x00000004
    }

    /// <summary>
    ///     Enum DEBUG_OUT_TEXT_REPL
    /// </summary>
    [Flags]
    public enum DEBUG_OUT_TEXT_REPL : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0
    }

    /// <summary>
    ///     Enum DEBUG_ASMOPT
    /// </summary>
    [Flags]
    public enum DEBUG_ASMOPT : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0x00000000,

        /// <summary>
        ///     The verbose
        /// </summary>
        VERBOSE = 0x00000001,

        /// <summary>
        ///     The no code bytes
        /// </summary>
        NO_CODE_BYTES = 0x00000002,

        /// <summary>
        ///     The ignore output width
        /// </summary>
        IGNORE_OUTPUT_WIDTH = 0x00000004,

        /// <summary>
        ///     The source line number
        /// </summary>
        SOURCE_LINE_NUMBER = 0x00000008
    }

    /// <summary>
    ///     Enum DEBUG_EXPR
    /// </summary>
    public enum DEBUG_EXPR : uint
    {
        /// <summary>
        ///     The masm
        /// </summary>
        MASM = 0,

        /// <summary>
        ///     The cplusplus
        /// </summary>
        CPLUSPLUS = 1
    }

    /// <summary>
    ///     Enum DEBUG_EINDEX
    /// </summary>
    public enum DEBUG_EINDEX : uint
    {
        /// <summary>
        ///     The name
        /// </summary>
        NAME = 0,

        /// <summary>
        ///     From start
        /// </summary>
        FROM_START = 0,

        /// <summary>
        ///     From end
        /// </summary>
        FROM_END = 1,

        /// <summary>
        ///     From current
        /// </summary>
        FROM_CURRENT = 2
    }

    /// <summary>
    ///     Enum DEBUG_LOG
    /// </summary>
    [Flags]
    public enum DEBUG_LOG : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The append
        /// </summary>
        APPEND = 1,

        /// <summary>
        ///     The unicode
        /// </summary>
        UNICODE = 2,

        /// <summary>
        ///     The DML
        /// </summary>
        DML = 4
    }

    /// <summary>
    ///     Enum DEBUG_SYSVERSTR
    /// </summary>
    public enum DEBUG_SYSVERSTR : uint
    {
        /// <summary>
        ///     The service pack
        /// </summary>
        SERVICE_PACK = 0,

        /// <summary>
        ///     The build
        /// </summary>
        BUILD = 1
    }

    /// <summary>
    ///     Enum DEBUG_MANAGED
    /// </summary>
    [Flags]
    public enum DEBUG_MANAGED : uint
    {
        /// <summary>
        ///     The disabled
        /// </summary>
        DISABLED = 0,

        /// <summary>
        ///     The allowed
        /// </summary>
        ALLOWED = 1,

        /// <summary>
        ///     The DLL loaded
        /// </summary>
        DLL_LOADED = 2
    }

    /// <summary>
    ///     Enum DEBUG_MANSTR
    /// </summary>
    [Flags]
    public enum DEBUG_MANSTR : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     The loaded support DLL
        /// </summary>
        LOADED_SUPPORT_DLL = 1,

        /// <summary>
        ///     The load status
        /// </summary>
        LOAD_STATUS = 2
    }

    /// <summary>
    ///     Enum DEBUG_MANRESET
    /// </summary>
    [Flags]
    public enum DEBUG_MANRESET : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The load DLL
        /// </summary>
        LOAD_DLL = 1
    }

    /// <summary>
    ///     Enum VS_FF
    /// </summary>
    [Flags]
    public enum VS_FF : uint
    {
        /// <summary>
        ///     The debug
        /// </summary>
        DEBUG = 0x00000001,

        /// <summary>
        ///     The prerelease
        /// </summary>
        PRERELEASE = 0x00000002,

        /// <summary>
        ///     The patched
        /// </summary>
        PATCHED = 0x00000004,

        /// <summary>
        ///     The privatebuild
        /// </summary>
        PRIVATEBUILD = 0x00000008,

        /// <summary>
        ///     The infoinferred
        /// </summary>
        INFOINFERRED = 0x00000010,

        /// <summary>
        ///     The specialbuild
        /// </summary>
        SPECIALBUILD = 0x00000020
    }

    /// <summary>
    ///     Enum MODULE_ARCHITECTURE
    /// </summary>
    public enum MODULE_ARCHITECTURE
    {
        /// <summary>
        ///     The unknown
        /// </summary>
        UNKNOWN,

        /// <summary>
        ///     The i386
        /// </summary>
        I386,

        /// <summary>
        ///     The X64
        /// </summary>
        X64,

        /// <summary>
        ///     The i a64
        /// </summary>
        IA64,

        /// <summary>
        ///     Any
        /// </summary>
        ANY
    }

    /// <summary>
    ///     Enum IG
    /// </summary>
    public enum IG : ushort
    {
        /// <summary>
        ///     The kd context
        /// </summary>
        KD_CONTEXT = 1,

        /// <summary>
        ///     The read control space
        /// </summary>
        READ_CONTROL_SPACE = 2,

        /// <summary>
        ///     The write control space
        /// </summary>
        WRITE_CONTROL_SPACE = 3,

        /// <summary>
        ///     The read io space
        /// </summary>
        READ_IO_SPACE = 4,

        /// <summary>
        ///     The write io space
        /// </summary>
        WRITE_IO_SPACE = 5,

        /// <summary>
        ///     The read physical
        /// </summary>
        READ_PHYSICAL = 6,

        /// <summary>
        ///     The write physical
        /// </summary>
        WRITE_PHYSICAL = 7,

        /// <summary>
        ///     The read io space ex
        /// </summary>
        READ_IO_SPACE_EX = 8,

        /// <summary>
        ///     The write io space ex
        /// </summary>
        WRITE_IO_SPACE_EX = 9,

        /// <summary>
        ///     The kstack help
        /// </summary>
        KSTACK_HELP = 10, // obsolete

        /// <summary>
        ///     The set thread
        /// </summary>
        SET_THREAD = 11,

        /// <summary>
        ///     The read MSR
        /// </summary>
        READ_MSR = 12,

        /// <summary>
        ///     The write MSR
        /// </summary>
        WRITE_MSR = 13,

        /// <summary>
        ///     The get debugger data
        /// </summary>
        GET_DEBUGGER_DATA = 14,

        /// <summary>
        ///     The get kernel version
        /// </summary>
        GET_KERNEL_VERSION = 15,

        /// <summary>
        ///     The reload symbols
        /// </summary>
        RELOAD_SYMBOLS = 16,

        /// <summary>
        ///     The get set sympath
        /// </summary>
        GET_SET_SYMPATH = 17,

        /// <summary>
        ///     The get exception record
        /// </summary>
        GET_EXCEPTION_RECORD = 18,

        /// <summary>
        ///     The is pt R64
        /// </summary>
        IS_PTR64 = 19,

        /// <summary>
        ///     The get bus data
        /// </summary>
        GET_BUS_DATA = 20,

        /// <summary>
        ///     The set bus data
        /// </summary>
        SET_BUS_DATA = 21,

        /// <summary>
        ///     The dump symbol information
        /// </summary>
        DUMP_SYMBOL_INFO = 22,

        /// <summary>
        ///     The lowmem check
        /// </summary>
        LOWMEM_CHECK = 23,

        /// <summary>
        ///     The search memory
        /// </summary>
        SEARCH_MEMORY = 24,

        /// <summary>
        ///     The get current thread
        /// </summary>
        GET_CURRENT_THREAD = 25,

        /// <summary>
        ///     The get current process
        /// </summary>
        GET_CURRENT_PROCESS = 26,

        /// <summary>
        ///     The get type size
        /// </summary>
        GET_TYPE_SIZE = 27,

        /// <summary>
        ///     The get current process handle
        /// </summary>
        GET_CURRENT_PROCESS_HANDLE = 28,

        /// <summary>
        ///     The get input line
        /// </summary>
        GET_INPUT_LINE = 29,

        /// <summary>
        ///     The get expression ex
        /// </summary>
        GET_EXPRESSION_EX = 30,

        /// <summary>
        ///     The translate virtual to physical
        /// </summary>
        TRANSLATE_VIRTUAL_TO_PHYSICAL = 31,

        /// <summary>
        ///     The get cache size
        /// </summary>
        GET_CACHE_SIZE = 32,

        /// <summary>
        ///     The read physical with flags
        /// </summary>
        READ_PHYSICAL_WITH_FLAGS = 33,

        /// <summary>
        ///     The write physical with flags
        /// </summary>
        WRITE_PHYSICAL_WITH_FLAGS = 34,

        /// <summary>
        ///     The pointer search physical
        /// </summary>
        POINTER_SEARCH_PHYSICAL = 35,

        /// <summary>
        ///     The obsolete placeholder 36
        /// </summary>
        OBSOLETE_PLACEHOLDER_36 = 36,

        /// <summary>
        ///     The get thread os information
        /// </summary>
        GET_THREAD_OS_INFO = 37,

        /// <summary>
        ///     The get color data interface
        /// </summary>
        GET_CLR_DATA_INTERFACE = 38,

        /// <summary>
        ///     The match pattern a
        /// </summary>
        MATCH_PATTERN_A = 39,

        /// <summary>
        ///     The find file
        /// </summary>
        FIND_FILE = 40,

        /// <summary>
        ///     The typed data obsolete
        /// </summary>
        TYPED_DATA_OBSOLETE = 41,

        /// <summary>
        ///     The query target interface
        /// </summary>
        QUERY_TARGET_INTERFACE = 42,

        /// <summary>
        ///     The typed data
        /// </summary>
        TYPED_DATA = 43,

        /// <summary>
        ///     The disassemble buffer
        /// </summary>
        DISASSEMBLE_BUFFER = 44,

        /// <summary>
        ///     The get any module in range
        /// </summary>
        GET_ANY_MODULE_IN_RANGE = 45,

        /// <summary>
        ///     The virtual to physical
        /// </summary>
        VIRTUAL_TO_PHYSICAL = 46,

        /// <summary>
        ///     The physical to virtual
        /// </summary>
        PHYSICAL_TO_VIRTUAL = 47,

        /// <summary>
        ///     The get context ex
        /// </summary>
        GET_CONTEXT_EX = 48,

        /// <summary>
        ///     The get teb address
        /// </summary>
        GET_TEB_ADDRESS = 128,

        /// <summary>
        ///     The get peb address
        /// </summary>
        GET_PEB_ADDRESS = 129
    }

    /// <summary>
    ///     Enum EFileAccess
    /// </summary>
    [Flags]
    public enum EFileAccess : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The generic read
        /// </summary>
        GenericRead = 0x80000000,

        /// <summary>
        ///     The generic write
        /// </summary>
        GenericWrite = 0x40000000,

        /// <summary>
        ///     The generic execute
        /// </summary>
        GenericExecute = 0x20000000,

        /// <summary>
        ///     The generic all
        /// </summary>
        GenericAll = 0x10000000
    }

    /// <summary>
    ///     Enum EFileShare
    /// </summary>
    [Flags]
    public enum EFileShare : uint
    {
        /// <summary>
        ///     The none
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The read
        /// </summary>
        Read = 0x00000001,

        /// <summary>
        ///     The write
        /// </summary>
        Write = 0x00000002,

        /// <summary>
        ///     The delete
        /// </summary>
        Delete = 0x00000004
    }

    /// <summary>
    ///     Enum ECreationDisposition
    /// </summary>
    public enum ECreationDisposition : uint
    {
        /// <summary>
        ///     Creates a new file. The function fails if a specified file exists.
        /// </summary>
        New = 1,

        /// <summary>
        ///     Creates a new file, always.
        ///     If a file exists, the function overwrites the file, clears the existing attributes, combines the specified file
        ///     attributes,
        ///     and flags with FILE_ATTRIBUTE_ARCHIVE, but does not set the security descriptor that the SECURITY_ATTRIBUTES
        ///     structure specifies.
        /// </summary>
        CreateAlways = 2,

        /// <summary>
        ///     Opens a file. The function fails if the file does not exist.
        /// </summary>
        OpenExisting = 3,

        /// <summary>
        ///     Opens a file, always.
        ///     If a file does not exist, the function creates a file as if dwCreationDisposition is CREATE_NEW.
        /// </summary>
        OpenAlways = 4,

        /// <summary>
        ///     Opens a file and truncates it so that its size is 0 (zero) bytes. The function fails if the file does not exist.
        ///     The calling process must open the file with the GENERIC_WRITE access right.
        /// </summary>
        TruncateExisting = 5
    }

    /// <summary>
    ///     Enum EFileAttributes
    /// </summary>
    [Flags]
    public enum EFileAttributes : uint
    {
        /// <summary>
        ///     The readonly
        /// </summary>
        Readonly = 0x00000001,

        /// <summary>
        ///     The hidden
        /// </summary>
        Hidden = 0x00000002,

        /// <summary>
        ///     The system
        /// </summary>
        System = 0x00000004,

        /// <summary>
        ///     The directory
        /// </summary>
        Directory = 0x00000010,

        /// <summary>
        ///     The archive
        /// </summary>
        Archive = 0x00000020,

        /// <summary>
        ///     The device
        /// </summary>
        Device = 0x00000040,

        /// <summary>
        ///     The normal
        /// </summary>
        Normal = 0x00000080,

        /// <summary>
        ///     The temporary
        /// </summary>
        Temporary = 0x00000100,

        /// <summary>
        ///     The sparse file
        /// </summary>
        SparseFile = 0x00000200,

        /// <summary>
        ///     The reparse point
        /// </summary>
        ReparsePoint = 0x00000400,

        /// <summary>
        ///     The compressed
        /// </summary>
        Compressed = 0x00000800,

        /// <summary>
        ///     The offline
        /// </summary>
        Offline = 0x00001000,

        /// <summary>
        ///     The not content indexed
        /// </summary>
        NotContentIndexed = 0x00002000,

        /// <summary>
        ///     The encrypted
        /// </summary>
        Encrypted = 0x00004000,

        /// <summary>
        ///     The write through
        /// </summary>
        Write_Through = 0x80000000,

        /// <summary>
        ///     The overlapped
        /// </summary>
        Overlapped = 0x40000000,

        /// <summary>
        ///     The no buffering
        /// </summary>
        NoBuffering = 0x20000000,

        /// <summary>
        ///     The random access
        /// </summary>
        RandomAccess = 0x10000000,

        /// <summary>
        ///     The sequential scan
        /// </summary>
        SequentialScan = 0x08000000,

        /// <summary>
        ///     The delete on close
        /// </summary>
        DeleteOnClose = 0x04000000,

        /// <summary>
        ///     The backup semantics
        /// </summary>
        BackupSemantics = 0x02000000,

        /// <summary>
        ///     The posix semantics
        /// </summary>
        PosixSemantics = 0x01000000,

        /// <summary>
        ///     The open reparse point
        /// </summary>
        OpenReparsePoint = 0x00200000,

        /// <summary>
        ///     The open no recall
        /// </summary>
        OpenNoRecall = 0x00100000,

        /// <summary>
        ///     The first pipe instance
        /// </summary>
        FirstPipeInstance = 0x00080000
    }

    /// <summary>
    ///     Enum SPF_MOVE_METHOD
    /// </summary>
    public enum SPF_MOVE_METHOD : uint
    {
        /// <summary>
        ///     The file begin
        /// </summary>
        FILE_BEGIN = 0,

        /// <summary>
        ///     The file current
        /// </summary>
        FILE_CURRENT = 1,

        /// <summary>
        ///     The file end
        /// </summary>
        FILE_END = 2
    }

    /// <summary>
    ///     Enum DEBUG_GETMOD
    /// </summary>
    [Flags]
    public enum DEBUG_GETMOD : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no loaded modules
        /// </summary>
        NO_LOADED_MODULES = 1,

        /// <summary>
        ///     The no unloaded modules
        /// </summary>
        NO_UNLOADED_MODULES = 2
    }

    /// <summary>
    ///     Enum DEBUG_ADDSYNTHMOD
    /// </summary>
    [Flags]
    public enum DEBUG_ADDSYNTHMOD : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0
    }

    /// <summary>
    ///     Enum DEBUG_ADDSYNTHSYM
    /// </summary>
    [Flags]
    public enum DEBUG_ADDSYNTHSYM : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0
    }

    /// <summary>
    ///     Enum DEBUG_OUTSYM
    /// </summary>
    [Flags]
    public enum DEBUG_OUTSYM : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The force offset
        /// </summary>
        FORCE_OFFSET = 1,

        /// <summary>
        ///     The source line
        /// </summary>
        SOURCE_LINE = 2,

        /// <summary>
        ///     The allow displacement
        /// </summary>
        ALLOW_DISPLACEMENT = 4
    }

    /// <summary>
    ///     Enum DEBUG_GETFNENT
    /// </summary>
    [Flags]
    public enum DEBUG_GETFNENT : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The raw entry only
        /// </summary>
        RAW_ENTRY_ONLY = 1
    }

    /// <summary>
    ///     Enum DEBUG_SOURCE
    /// </summary>
    [Flags]
    public enum DEBUG_SOURCE : uint
    {
        /// <summary>
        ///     The is statement
        /// </summary>
        IS_STATEMENT = 1
    }

    /// <summary>
    ///     Enum DEBUG_GSEL
    /// </summary>
    [Flags]
    public enum DEBUG_GSEL : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The no symbol loads
        /// </summary>
        NO_SYMBOL_LOADS = 1,

        /// <summary>
        ///     The allow lower
        /// </summary>
        ALLOW_LOWER = 2,

        /// <summary>
        ///     The allow higher
        /// </summary>
        ALLOW_HIGHER = 4,

        /// <summary>
        ///     The nearest only
        /// </summary>
        NEAREST_ONLY = 8,

        /// <summary>
        ///     The inline callsite
        /// </summary>
        INLINE_CALLSITE = 0x10
    }

    /// <summary>
    ///     Enum DEBUG_FRAME
    /// </summary>
    [Flags]
    public enum DEBUG_FRAME : uint
    {
        /// <summary>
        ///     The default
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     The ignore inline
        /// </summary>
        IGNORE_INLINE = 1
    }

    /// <summary>
    ///     Enum DEBUG_REGSRC
    /// </summary>
    public enum DEBUG_REGSRC : uint
    {
        /// <summary>
        ///     The debuggee
        /// </summary>
        DEBUGGEE = 0,

        /// <summary>
        ///     The explicit
        /// </summary>
        EXPLICIT = 1,

        /// <summary>
        ///     The frame
        /// </summary>
        FRAME = 2
    }

    /// <summary>
    ///     Enum _EXT_TDOP
    /// </summary>
    public enum _EXT_TDOP
    {
        /// <summary>
        ///     The ext tdop copy
        /// </summary>
        EXT_TDOP_COPY,

        /// <summary>
        ///     The ext tdop release
        /// </summary>
        EXT_TDOP_RELEASE,

        /// <summary>
        ///     The ext tdop set from expr
        /// </summary>
        EXT_TDOP_SET_FROM_EXPR,

        /// <summary>
        ///     The ext tdop set from u64 expr
        /// </summary>
        EXT_TDOP_SET_FROM_U64_EXPR,

        /// <summary>
        ///     The ext tdop get field
        /// </summary>
        EXT_TDOP_GET_FIELD,

        /// <summary>
        ///     The ext tdop evaluate
        /// </summary>
        EXT_TDOP_EVALUATE,

        /// <summary>
        ///     The ext tdop get type name
        /// </summary>
        EXT_TDOP_GET_TYPE_NAME,

        /// <summary>
        ///     The ext tdop output type name
        /// </summary>
        EXT_TDOP_OUTPUT_TYPE_NAME,

        /// <summary>
        ///     The ext tdop output simple value
        /// </summary>
        EXT_TDOP_OUTPUT_SIMPLE_VALUE,

        /// <summary>
        ///     The ext tdop output full value
        /// </summary>
        EXT_TDOP_OUTPUT_FULL_VALUE,

        /// <summary>
        ///     The ext tdop has field
        /// </summary>
        EXT_TDOP_HAS_FIELD,

        /// <summary>
        ///     The ext tdop get field offset
        /// </summary>
        EXT_TDOP_GET_FIELD_OFFSET,

        /// <summary>
        ///     The ext tdop get array element
        /// </summary>
        EXT_TDOP_GET_ARRAY_ELEMENT,

        /// <summary>
        ///     The ext tdop get dereference
        /// </summary>
        EXT_TDOP_GET_DEREFERENCE,

        /// <summary>
        ///     The ext tdop get type size
        /// </summary>
        EXT_TDOP_GET_TYPE_SIZE,

        /// <summary>
        ///     The ext tdop output type definition
        /// </summary>
        EXT_TDOP_OUTPUT_TYPE_DEFINITION,

        /// <summary>
        ///     The ext tdop get pointer to
        /// </summary>
        EXT_TDOP_GET_POINTER_TO,

        /// <summary>
        ///     The ext tdop set from type identifier and u64
        /// </summary>
        EXT_TDOP_SET_FROM_TYPE_ID_AND_U64,

        /// <summary>
        ///     The ext tdop set PTR from type identifier and u64
        /// </summary>
        EXT_TDOP_SET_PTR_FROM_TYPE_ID_AND_U64,

        /// <summary>
        ///     The ext tdop count
        /// </summary>
        EXT_TDOP_COUNT
    }

    /// <summary>
    ///     Enum FORMAT_MESSAGE
    /// </summary>
    [Flags]
    public enum FORMAT_MESSAGE
    {
        /// <summary>
        ///     The allocate buffer
        /// </summary>
        ALLOCATE_BUFFER = 0x0100,

        /// <summary>
        ///     The ignore inserts
        /// </summary>
        IGNORE_INSERTS = 0x0200,

        /// <summary>
        ///     From string
        /// </summary>
        FROM_STRING = 0x0400,

        /// <summary>
        ///     From hmodule
        /// </summary>
        FROM_HMODULE = 0x0800,

        /// <summary>
        ///     From system
        /// </summary>
        FROM_SYSTEM = 0x1000,

        /// <summary>
        ///     The argument array
        /// </summary>
        ARGUMENT_ARRAY = 0x2000
    }
}