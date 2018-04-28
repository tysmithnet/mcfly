// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugSymbols2.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Interface IDebugSymbols2
    /// </summary>
    /// <seealso cref="IDebugSymbols" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3a707211-afdd-4495-ad4f-56fecdf8163f")]
    public interface IDebugSymbols2 : IDebugSymbols
    {
        /* IDebugSymbols */

        /// <summary>
        ///     Gets the symbol options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolOptions(
            [Out] out SYMOPT Options);

        /// <summary>
        ///     Adds the symbol options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddSymbolOptions(
            [In] SYMOPT Options);

        /// <summary>
        ///     Removes the symbol options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveSymbolOptions(
            [In] SYMOPT Options);

        /// <summary>
        ///     Sets the symbol options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSymbolOptions(
            [In] SYMOPT Options);

        /// <summary>
        ///     Gets the name by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNameByOffset(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        /// <summary>
        ///     Gets the name of the offset by.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffsetByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the near name by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Delta">The delta.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNearNameByOffset(
            [In] ulong Offset,
            [In] int Delta,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        /// <summary>
        ///     Gets the line by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Line">The line.</param>
        /// <param name="FileBuffer">The file buffer.</param>
        /// <param name="FileBufferSize">Size of the file buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLineByOffset(
            [In] ulong Offset,
            [Out] out uint Line,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

        /// <summary>
        ///     Gets the offset by line.
        /// </summary>
        /// <param name="Line">The line.</param>
        /// <param name="File">The file.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffsetByLine(
            [In] uint Line,
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the number modules.
        /// </summary>
        /// <param name="Loaded">The loaded.</param>
        /// <param name="Unloaded">The unloaded.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberModules(
            [Out] out uint Loaded,
            [Out] out uint Unloaded);

        /// <summary>
        ///     Gets the index of the module by.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByIndex(
            [In] uint Index,
            [Out] out ulong Base);

        /// <summary>
        ///     Gets the name of the module by module.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByModuleName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

        /// <summary>
        ///     Gets the module by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByOffset(
            [In] ulong Offset,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

        /// <summary>
        ///     Gets the module names.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <param name="ImageNameBuffer">The image name buffer.</param>
        /// <param name="ImageNameBufferSize">Size of the image name buffer.</param>
        /// <param name="ImageNameSize">Size of the image name.</param>
        /// <param name="ModuleNameBuffer">The module name buffer.</param>
        /// <param name="ModuleNameBufferSize">Size of the module name buffer.</param>
        /// <param name="ModuleNameSize">Size of the module name.</param>
        /// <param name="LoadedImageNameBuffer">The loaded image name buffer.</param>
        /// <param name="LoadedImageNameBufferSize">Size of the loaded image name buffer.</param>
        /// <param name="LoadedImageNameSize">Size of the loaded image name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleNames(
            [In] uint Index,
            [In] ulong Base,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder ImageNameBuffer,
            [In] int ImageNameBufferSize,
            [Out] out uint ImageNameSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder ModuleNameBuffer,
            [In] int ModuleNameBufferSize,
            [Out] out uint ModuleNameSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder LoadedImageNameBuffer,
            [In] int LoadedImageNameBufferSize,
            [Out] out uint LoadedImageNameSize);

        /// <summary>
        ///     Gets the module parameters.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Bases">The bases.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleParameters(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Bases,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_MODULE_PARAMETERS[] Params);

        /// <summary>
        ///     Gets the symbol module.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolModule(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out ulong Base);

        /// <summary>
        ///     Gets the name of the type.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTypeName(
            [In] ulong Module,
            [In] uint TypeId,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the type identifier.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="Name">The name.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTypeId(
            [In] ulong Module,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint TypeId);

        /// <summary>
        ///     Gets the size of the type.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Size">The size.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTypeSize(
            [In] ulong Module,
            [In] uint TypeId,
            [Out] out uint Size);

        /// <summary>
        ///     Gets the field offset.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Field">The field.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFieldOffset(
            [In] ulong Module,
            [In] uint TypeId,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint Offset);

        /// <summary>
        ///     Gets the symbol type identifier.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Module">The module.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolTypeId(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out uint TypeId,
            [Out] out ulong Module);

        /// <summary>
        ///     Gets the offset type identifier.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Module">The module.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffsetTypeId(
            [In] ulong Offset,
            [Out] out uint TypeId,
            [Out] out ulong Module);

        /// <summary>
        ///     Reads the typed data virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadTypedDataVirtual(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the typed data virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteTypedDataVirtual(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Outputs the typed data virtual.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputTypedDataVirtual(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);

        /// <summary>
        ///     Reads the typed data physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadTypedDataPhysical(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the typed data physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteTypedDataPhysical(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Outputs the typed data physical.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputTypedDataPhysical(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);

        /// <summary>
        ///     Gets the scope.
        /// </summary>
        /// <param name="InstructionOffset">The instruction offset.</param>
        /// <param name="ScopeFrame">The scope frame.</param>
        /// <param name="ScopeContext">The scope context.</param>
        /// <param name="ScopeContextSize">Size of the scope context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetScope(
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

        /// <summary>
        ///     Sets the scope.
        /// </summary>
        /// <param name="InstructionOffset">The instruction offset.</param>
        /// <param name="ScopeFrame">The scope frame.</param>
        /// <param name="ScopeContext">The scope context.</param>
        /// <param name="ScopeContextSize">Size of the scope context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetScope(
            [In] ulong InstructionOffset,
            [In] ref DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

        /// <summary>
        ///     Resets the scope.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ResetScope();

        /// <summary>
        ///     Gets the scope symbol group.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Update">The update.</param>
        /// <param name="Symbols">The symbols.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetScopeSymbolGroup(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In] [MarshalAs(UnmanagedType.Interface)]
            IDebugSymbolGroup Update,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugSymbolGroup Symbols);

        /// <summary>
        ///     Creates the symbol group.
        /// </summary>
        /// <param name="Group">The group.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CreateSymbolGroup(
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugSymbolGroup Group);

        /// <summary>
        ///     Starts the symbol match.
        /// </summary>
        /// <param name="Pattern">The pattern.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int StartSymbolMatch(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Pattern,
            [Out] out ulong Handle);

        /// <summary>
        ///     Gets the next symbol match.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="MatchSize">Size of the match.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNextSymbolMatch(
            [In] ulong Handle,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);

        /// <summary>
        ///     Ends the symbol match.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int EndSymbolMatch(
            [In] ulong Handle);

        /// <summary>
        ///     Reloads the specified module.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Reload(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Module);

        /// <summary>
        ///     Gets the symbol path.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PathSize">Size of the path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolPath(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        /// <summary>
        ///     Sets the symbol path.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSymbolPath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Path);

        /// <summary>
        ///     Appends the symbol path.
        /// </summary>
        /// <param name="Addition">The addition.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AppendSymbolPath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Addition);

        /// <summary>
        ///     Gets the image path.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PathSize">Size of the path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetImagePath(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        /// <summary>
        ///     Sets the image path.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetImagePath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Path);

        /// <summary>
        ///     Appends the image path.
        /// </summary>
        /// <param name="Addition">The addition.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AppendImagePath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Addition);

        /// <summary>
        ///     Gets the source path.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PathSize">Size of the path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourcePath(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        /// <summary>
        ///     Gets the source path element.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ElementSize">Size of the element.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourcePathElement(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);

        /// <summary>
        ///     Sets the source path.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSourcePath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Path);

        /// <summary>
        ///     Appends the source path.
        /// </summary>
        /// <param name="Addition">The addition.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AppendSourcePath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Addition);

        /// <summary>
        ///     Finds the source file.
        /// </summary>
        /// <param name="StartElement">The start element.</param>
        /// <param name="File">The file.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="FoundElement">The found element.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="FoundSize">Size of the found.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int FindSourceFile(
            [In] uint StartElement,
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);

        /// <summary>
        ///     Gets the source file line offsets.
        /// </summary>
        /// <param name="File">The file.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferLines">The buffer lines.</param>
        /// <param name="FileLines">The file lines.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceFileLineOffsets(
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);

        /* IDebugSymbols2 */

        /// <summary>
        ///     Gets the module version information.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <param name="Item">The item.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="VerInfoSize">Size of the ver information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetModuleVersionInformation(
            [In] uint Index,
            [In] ulong Base,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Item,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint VerInfoSize);

        /// <summary>
        ///     Gets the module name string.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetModuleNameString(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the name of the constant.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Value">The value.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetConstantName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the name of the field.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="FieldIndex">Index of the field.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetFieldName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetTypeOptions(
            [Out] out DEBUG_TYPEOPTS Options);

        /// <summary>
        ///     Adds the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AddTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /// <summary>
        ///     Removes the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /// <summary>
        ///     Sets the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);
    }
}