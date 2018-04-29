// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="DomainEntityConversion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class DomainEntityConversion.
    /// </summary>
    internal static class DomainEntityExtensions
    {
        
        /// <summary>
        ///     To the stack frame.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>StackFrame.</returns>
        public static StackFrame ToStackFrame(this StackFrameEntity entity)
        {
            return new StackFrame(entity.StackPointer.ToULong(), entity.ReturnAddress?.ToULong(), entity.ModuleName,
                entity.Function, entity.Offset?.ToULong());
        }


        /// <summary>
        ///     To the stack frame entity.
        /// </summary>
        /// <param name="stackFrame">The stack frame.</param>
        /// <returns>StackFrameEntity.</returns>
        public static StackFrameEntity ToStackFrameEntity(this StackFrame stackFrame)
        {
            var entity = new StackFrameEntity();
            entity.StackPointer = stackFrame.StackPointer.ToHexString();
            entity.ReturnAddress = stackFrame.ReturnAddress?.ToHexString();
            entity.ModuleName = stackFrame.Module;
            entity.Function = stackFrame.FunctionName;
            entity.Offset = stackFrame.Offset?.ToLong();
            return entity;
        }

        public static MemoryChunkEntity ToMemoryChunkEntity(this MemoryChunk memoryChunk)
        {
             var memoryChunkEntity = new MemoryChunkEntity();

            //memoryChunkEntity.ByteRange  = new ByteRangeEntity();
            //memoryChunkEntity.ByteRange.Bytes = memoryChunk.Bytes.ToHexString();
            //memoryChunkEntity.LowAddress = memoryChunk.MemoryRange.LowAddress.ToHexString();
            //memoryChunkEntity.HighAddress = memoryChunk.MemoryRange.HighAddress.ToHexString();
            //memoryChunkEntity.PosHi = memoryChunk.Position.High;
            //memoryChunkEntity.PosLo = memoryChunk.Position.Low;
            

            return memoryChunkEntity;
        }

        public static MemoryChunk ToMemoryChunk(this MemoryChunkEntity entity)
        {
            return new MemoryChunk
            {
                
            };
        }
    }
}