// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugSymbols4.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugSymbols4
    /// </summary>
    /// <seealso cref="McFly.Debugger.IDebugSymbols3" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("e391bbd8-9d8c-4418-840b-c006592a1752")]
    public interface IDebugSymbols4 : IDebugSymbols3
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
        new int GetModuleVersionInformation(
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
        new int GetModuleNameString(
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
        new int GetConstantName(
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
        new int GetFieldName(
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
        new int GetTypeOptions(
            [Out] out DEBUG_TYPEOPTS Options);

        /// <summary>
        ///     Adds the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /// <summary>
        ///     Removes the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /// <summary>
        ///     Sets the type options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /* IDebugSymbols3 */

        /// <summary>
        ///     Gets the name by offset wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNameByOffsetWide(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        /// <summary>
        ///     Gets the offset by name wide.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffsetByNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the near name by offset wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Delta">The delta.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNearNameByOffsetWide(
            [In] ulong Offset,
            [In] int Delta,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        /// <summary>
        ///     Gets the line by offset wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Line">The line.</param>
        /// <param name="FileBuffer">The file buffer.</param>
        /// <param name="FileBufferSize">Size of the file buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLineByOffsetWide(
            [In] ulong Offset,
            [Out] out uint Line,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

        /// <summary>
        ///     Gets the offset by line wide.
        /// </summary>
        /// <param name="Line">The line.</param>
        /// <param name="File">The file.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffsetByLineWide(
            [In] uint Line,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the module by module name wide.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByModuleNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

        /// <summary>
        ///     Gets the symbol module wide.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolModuleWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out ulong Base);

        /// <summary>
        ///     Gets the type name wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTypeNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the type identifier wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="Name">The name.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTypeIdWide(
            [In] ulong Module,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint TypeId);

        /// <summary>
        ///     Gets the field offset wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Field">The field.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFieldOffsetWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out uint Offset);

        /// <summary>
        ///     Gets the symbol type identifier wide.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Module">The module.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolTypeIdWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out uint TypeId,
            [Out] out ulong Module);

        /// <summary>
        ///     Gets the scope symbol group2.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Update">The update.</param>
        /// <param name="Symbols">The symbols.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetScopeSymbolGroup2(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In] [MarshalAs(UnmanagedType.Interface)]
            IDebugSymbolGroup2 Update,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugSymbolGroup2 Symbols);

        /// <summary>
        ///     Creates the symbol group2.
        /// </summary>
        /// <param name="Group">The group.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CreateSymbolGroup2(
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugSymbolGroup2 Group);

        /// <summary>
        ///     Starts the symbol match wide.
        /// </summary>
        /// <param name="Pattern">The pattern.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int StartSymbolMatchWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Pattern,
            [Out] out ulong Handle);

        /// <summary>
        ///     Gets the next symbol match wide.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="MatchSize">Size of the match.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNextSymbolMatchWide(
            [In] ulong Handle,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);

        /// <summary>
        ///     Reloads the wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReloadWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Module);

        /// <summary>
        ///     Gets the symbol path wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PathSize">Size of the path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolPathWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        /// <summary>
        ///     Sets the symbol path wide.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSymbolPathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Path);

        /// <summary>
        ///     Appends the symbol path wide.
        /// </summary>
        /// <param name="Addition">The addition.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AppendSymbolPathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Addition);

        /// <summary>
        ///     Gets the image path wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PathSize">Size of the path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetImagePathWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        /// <summary>
        ///     Sets the image path wide.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetImagePathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Path);

        /// <summary>
        ///     Appends the image path wide.
        /// </summary>
        /// <param name="Addition">The addition.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AppendImagePathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Addition);

        /// <summary>
        ///     Gets the source path wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PathSize">Size of the path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourcePathWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        /// <summary>
        ///     Gets the source path element wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ElementSize">Size of the element.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourcePathElementWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);

        /// <summary>
        ///     Sets the source path wide.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSourcePathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Path);

        /// <summary>
        ///     Appends the source path wide.
        /// </summary>
        /// <param name="Addition">The addition.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AppendSourcePathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Addition);

        /// <summary>
        ///     Finds the source file wide.
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
        new int FindSourceFileWide(
            [In] uint StartElement,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);

        /// <summary>
        ///     Gets the source file line offsets wide.
        /// </summary>
        /// <param name="File">The file.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferLines">The buffer lines.</param>
        /// <param name="FileLines">The file lines.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceFileLineOffsetsWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);

        /// <summary>
        ///     Gets the module version information wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <param name="Item">The item.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="VerInfoSize">Size of the ver information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleVersionInformationWide(
            [In] uint Index,
            [In] ulong Base,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Item,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint VerInfoSize);

        /// <summary>
        ///     Gets the module name string wide.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleNameStringWide(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the constant name wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="Value">The value.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetConstantNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the field name wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <param name="FieldIndex">Index of the field.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFieldNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Determines whether [is managed module] [the specified index].
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int IsManagedModule(
            [In] uint Index,
            [In] ulong Base
        );

        /// <summary>
        ///     Gets the module by module name2.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByModuleName2(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base
        );

        /// <summary>
        ///     Gets the module by module name2 wide.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByModuleName2Wide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base
        );

        /// <summary>
        ///     Gets the module by offset2.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="StartIndex">The start index.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Index">The index.</param>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetModuleByOffset2(
            [In] ulong Offset,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base
        );

        /// <summary>
        ///     Adds the synthetic module.
        /// </summary>
        /// <param name="Base">The base.</param>
        /// <param name="Size">The size.</param>
        /// <param name="ImagePath">The image path.</param>
        /// <param name="ModuleName">Name of the module.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddSyntheticModule(
            [In] ulong Base,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ImagePath,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags
        );

        /// <summary>
        ///     Adds the synthetic module wide.
        /// </summary>
        /// <param name="Base">The base.</param>
        /// <param name="Size">The size.</param>
        /// <param name="ImagePath">The image path.</param>
        /// <param name="ModuleName">Name of the module.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddSyntheticModuleWide(
            [In] ulong Base,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ImagePath,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags
        );

        /// <summary>
        ///     Removes the synthetic module.
        /// </summary>
        /// <param name="Base">The base.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveSyntheticModule(
            [In] ulong Base
        );

        /// <summary>
        ///     Gets the index of the current scope frame.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentScopeFrameIndex(
            [Out] out uint Index
        );

        /// <summary>
        ///     Sets the index of the scope frame by.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetScopeFrameByIndex(
            [In] uint Index
        );

        /// <summary>
        ///     Sets the scope from JIT debug information.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="InfoOffset">The information offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetScopeFromJitDebugInfo(
            [In] uint OutputControl,
            [In] ulong InfoOffset
        );

        /// <summary>
        ///     Sets the scope from stored event.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetScopeFromStoredEvent(
        );

        /// <summary>
        ///     Outputs the symbol by offset.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputSymbolByOffset(
            [In] uint OutputControl,
            [In] DEBUG_OUTSYM Flags,
            [In] ulong Offset
        );

        /// <summary>
        ///     Gets the function entry by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BufferNeeded">The buffer needed.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFunctionEntryByOffset(
            [In] ulong Offset,
            [In] DEBUG_GETFNENT Flags,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BufferNeeded
        );

        /// <summary>
        ///     Gets the field type and offset.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="ContainerTypeId">The container type identifier.</param>
        /// <param name="Field">The field.</param>
        /// <param name="FieldTypeId">The field type identifier.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFieldTypeAndOffset(
            [In] ulong Module,
            [In] uint ContainerTypeId,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint FieldTypeId,
            [Out] out uint Offset
        );

        /// <summary>
        ///     Gets the field type and offset wide.
        /// </summary>
        /// <param name="Module">The module.</param>
        /// <param name="ContainerTypeId">The container type identifier.</param>
        /// <param name="Field">The field.</param>
        /// <param name="FieldTypeId">The field type identifier.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFieldTypeAndOffsetWide(
            [In] ulong Module,
            [In] uint ContainerTypeId,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out uint FieldTypeId,
            [Out] out uint Offset
        );

        /// <summary>
        ///     Adds the synthetic symbol.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Size">The size.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddSyntheticSymbol(
            [In] ulong Offset,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id
        );

        /// <summary>
        ///     Adds the synthetic symbol wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Size">The size.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddSyntheticSymbolWide(
            [In] ulong Offset,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id
        );

        /// <summary>
        ///     Removes the synthetic symbol.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveSyntheticSymbol([In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_MODULE_AND_ID Id
        );

        /// <summary>
        ///     Gets the symbol entries by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="Displacements">The displacements.</param>
        /// <param name="IdsCount">The ids count.</param>
        /// <param name="Entries">The entries.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntriesByOffset(
            [In] ulong Offset,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_MODULE_AND_ID[] Ids,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Displacements,
            [In] uint IdsCount,
            [Out] out uint Entries
        );

        /// <summary>
        ///     Gets the name of the symbol entries by.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="IdsCount">The ids count.</param>
        /// <param name="Entries">The entries.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntriesByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_MODULE_AND_ID[] Ids,
            [In] uint IdsCount,
            [Out] out uint Entries
        );

        /// <summary>
        ///     Gets the symbol entries by name wide.
        /// </summary>
        /// <param name="Symbol">The symbol.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="IdsCount">The ids count.</param>
        /// <param name="Entries">The entries.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntriesByNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_MODULE_AND_ID[] Ids,
            [In] uint IdsCount,
            [Out] out uint Entries
        );

        /// <summary>
        ///     Gets the symbol entry by token.
        /// </summary>
        /// <param name="ModuleBase">The module base.</param>
        /// <param name="Token">The token.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntryByToken(
            [In] ulong ModuleBase,
            [In] uint Token,
            [Out] out DEBUG_MODULE_AND_ID Id
        );

        /// <summary>
        ///     Gets the symbol entry information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Info">The information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntryInformation(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_MODULE_AND_ID Id,
            [Out] out DEBUG_SYMBOL_ENTRY Info
        );

        /// <summary>
        ///     Gets the symbol entry string.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntryString(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_MODULE_AND_ID Id,
            [In] uint Which,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize
        );

        /// <summary>
        ///     Gets the symbol entry string wide.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntryStringWide(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_MODULE_AND_ID Id,
            [In] uint Which,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize
        );

        /// <summary>
        ///     Gets the symbol entry offset regions.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Regions">The regions.</param>
        /// <param name="RegionsCount">The regions count.</param>
        /// <param name="RegionsAvail">The regions avail.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolEntryOffsetRegions(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_MODULE_AND_ID Id,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_OFFSET_REGION[] Regions,
            [In] uint RegionsCount,
            [Out] out uint RegionsAvail
        );

        /// <summary>
        ///     Gets the symbol entry by symbol entry.
        /// </summary>
        /// <param name="FromId">From identifier.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="ToId">To identifier.</param>
        /// <returns>System.Int32.</returns>
        [Obsolete("Do not use: no longer implemented.", true)]
        [PreserveSig]
        new int GetSymbolEntryBySymbolEntry(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_MODULE_AND_ID FromId,
            [In] uint Flags,
            [Out] out DEBUG_MODULE_AND_ID ToId
        );

        /// <summary>
        ///     Gets the source entries by offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Entries">The entries.</param>
        /// <param name="EntriesCount">The entries count.</param>
        /// <param name="EntriesAvail">The entries avail.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntriesByOffset(
            [In] ulong Offset,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail
        );

        /// <summary>
        ///     Gets the source entries by line.
        /// </summary>
        /// <param name="Line">The line.</param>
        /// <param name="File">The file.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Entries">The entries.</param>
        /// <param name="EntriesCount">The entries count.</param>
        /// <param name="EntriesAvail">The entries avail.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntriesByLine(
            [In] uint Line,
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail
        );

        /// <summary>
        ///     Gets the source entries by line wide.
        /// </summary>
        /// <param name="Line">The line.</param>
        /// <param name="File">The file.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Entries">The entries.</param>
        /// <param name="EntriesCount">The entries count.</param>
        /// <param name="EntriesAvail">The entries avail.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntriesByLineWide(
            [In] uint Line,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail
        );

        /// <summary>
        ///     Gets the source entry string.
        /// </summary>
        /// <param name="Entry">The entry.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntryString(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Which,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize
        );

        /// <summary>
        ///     Gets the source entry string wide.
        /// </summary>
        /// <param name="Entry">The entry.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntryStringWide(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Which,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize
        );

        /// <summary>
        ///     Gets the source entry offset regions.
        /// </summary>
        /// <param name="Entry">The entry.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Regions">The regions.</param>
        /// <param name="RegionsCount">The regions count.</param>
        /// <param name="RegionsAvail">The regions avail.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntryOffsetRegions(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_OFFSET_REGION[] Regions,
            [In] uint RegionsCount,
            [Out] out uint RegionsAvail
        );

        /// <summary>
        ///     Gets the source entry by source entry.
        /// </summary>
        /// <param name="FromEntry">From entry.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="ToEntry">To entry.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSourceEntryBySourceEntry(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_SYMBOL_SOURCE_ENTRY FromEntry,
            [In] uint Flags,
            [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry
        );

        /* IDebugSymbols4 */

        /// <summary>
        ///     Gets the scope ex.
        /// </summary>
        /// <param name="InstructionOffset">The instruction offset.</param>
        /// <param name="ScopeFrame">The scope frame.</param>
        /// <param name="ScopeContext">The scope context.</param>
        /// <param name="ScopeContextSize">Size of the scope context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetScopeEx(
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize
        );

        /// <summary>
        ///     Sets the scope ex.
        /// </summary>
        /// <param name="InstructionOffset">The instruction offset.</param>
        /// <param name="ScopeFrame">The scope frame.</param>
        /// <param name="ScopeContext">The scope context.</param>
        /// <param name="ScopeContextSize">Size of the scope context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetScopeEx(
            [In] ulong InstructionOffset,
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize
        );

        /// <summary>
        ///     Gets the name by inline context.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="InlineContext">The inline context.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNameByInlineContext(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement
        );

        /// <summary>
        ///     Gets the name by inline context wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="InlineContext">The inline context.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNameByInlineContextWide(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement
        );

        /// <summary>
        ///     Gets the line by inline context.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="InlineContext">The inline context.</param>
        /// <param name="Line">The line.</param>
        /// <param name="FileBuffer">The file buffer.</param>
        /// <param name="FileBufferSize">Size of the file buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetLineByInlineContext(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] out uint Line,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement
        );

        /// <summary>
        ///     Gets the line by inline context wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="InlineContext">The inline context.</param>
        /// <param name="Line">The line.</param>
        /// <param name="FileBuffer">The file buffer.</param>
        /// <param name="FileBufferSize">Size of the file buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Displacement">The displacement.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetLineByInlineContextWide(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] out uint Line,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement
        );

        /// <summary>
        ///     Outputs the symbol by inline context.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="InlineContext">The inline context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputSymbolByInlineContext(
            [In] uint OutputControl,
            [In] uint Flags,
            [In] ulong Offset,
            [In] uint InlineContext
        );
    }
}