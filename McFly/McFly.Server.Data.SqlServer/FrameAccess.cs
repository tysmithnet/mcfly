// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="FrameAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common.Logging;
using LinqKit;
using McFly.Core;
using McFly.Server.Data.Search;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Represents the data access logic for the frame domain
    /// </summary>
    /// <seealso cref="McFly.Server.Data.SqlServer.DataAccess" />
    /// <seealso cref="DataAccess" />
    /// <seealso cref="McFly.Server.Data.IFrameAccess" />
    [Export(typeof(IFrameAccess))]
    [Export(typeof(FrameAccess))]
    internal class FrameAccess : DataAccess, IFrameAccess
    {
        /// <summary>
        ///     The log
        /// </summary>
        private ILog Log = LogManager.GetLogger<FrameAccess>(); // todo: fix logging in mcfly

        /// <summary>
        ///     Gets or sets the context factory.
        /// </summary>
        /// <value>The context factory.</value>
        [Import]
        protected internal IContextFactory ContextFactory { get; set; }

        /// <summary>
        ///     To the frame entity.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <param name="context"></param>
        /// <returns>FrameEntity.</returns>
        public FrameEntity ConvertFrameToEntity(Frame frame, IMcFlyContext context)
        {
            var entity = new FrameEntity();
            entity.PosHi = frame.Position.High;
            entity.PosLo = frame.Position.Low;
            entity.ThreadId = frame.ThreadId;
            entity.Brfrom = frame.RegisterSet.Brfrom?.ToHexString();
            entity.Brto = frame.RegisterSet.Brto?.ToHexString();
            entity.Cs = frame.RegisterSet.Cs?.ToHexString();
            entity.Dr0 = frame.RegisterSet.Dr0?.ToHexString();
            entity.Dr1 = frame.RegisterSet.Dr1?.ToHexString();
            entity.Dr2 = frame.RegisterSet.Dr2?.ToHexString();
            entity.Dr3 = frame.RegisterSet.Dr3?.ToHexString();
            entity.Dr6 = frame.RegisterSet.Dr6?.ToHexString();
            entity.Dr7 = frame.RegisterSet.Dr7?.ToHexString();
            entity.Ds = frame.RegisterSet.Ds.ToHexString();
            entity.Efl = frame.RegisterSet.Efl?.ToHexString();
            entity.Es = frame.RegisterSet.Es?.ToHexString();
            entity.Exfrom = frame.RegisterSet.Exfrom?.ToHexString();
            entity.Exto = frame.RegisterSet.Exto?.ToHexString();
            entity.Fpcw = frame.RegisterSet.Fpcw?.ToHexString();
            entity.Fpsw = frame.RegisterSet.Fpsw?.ToHexString();
            entity.Fptw = frame.RegisterSet.Fptw?.ToHexString();
            entity.Fopcode = frame.RegisterSet.Fopcode?.ToHexString();
            entity.Fpip = frame.RegisterSet.Fpip?.ToHexString();
            entity.Fpipsel = frame.RegisterSet.Fpipsel?.ToHexString();
            entity.Fpdp = frame.RegisterSet.Fpdp?.ToHexString();
            entity.Fpdpsel = frame.RegisterSet.Fpdpsel?.ToHexString();
            entity.Fs = frame.RegisterSet.Fs?.ToHexString();
            entity.Gs = frame.RegisterSet.Gs?.ToHexString();
            entity.Mm0 = frame.RegisterSet.Mm0?.ToHexString();
            entity.Mm1 = frame.RegisterSet.Mm1?.ToHexString();
            entity.Mm2 = frame.RegisterSet.Mm2?.ToHexString();
            entity.Mm3 = frame.RegisterSet.Mm3?.ToHexString();
            entity.Mm4 = frame.RegisterSet.Mm4?.ToHexString();
            entity.Mm5 = frame.RegisterSet.Mm5?.ToHexString();
            entity.Mm6 = frame.RegisterSet.Mm6?.ToHexString();
            entity.Mm7 = frame.RegisterSet.Mm7?.ToHexString();
            entity.Mxcsr = frame.RegisterSet.Mxcsr?.ToHexString();
            entity.St0 = frame.RegisterSet.St0?.ToHexString(true);
            entity.St1 = frame.RegisterSet.St1?.ToHexString(true);
            entity.St2 = frame.RegisterSet.St2?.ToHexString(true);
            entity.St3 = frame.RegisterSet.St3?.ToHexString(true);
            entity.St4 = frame.RegisterSet.St4?.ToHexString(true);
            entity.St5 = frame.RegisterSet.St5?.ToHexString(true);
            entity.St6 = frame.RegisterSet.St6?.ToHexString(true);
            entity.St7 = frame.RegisterSet.St7?.ToHexString(true);
            entity.R10 = frame.RegisterSet.R10?.ToHexString();
            entity.R11 = frame.RegisterSet.R11?.ToHexString();
            entity.R12 = frame.RegisterSet.R12?.ToHexString();
            entity.R13 = frame.RegisterSet.R13?.ToHexString();
            entity.R14 = frame.RegisterSet.R14?.ToHexString();
            entity.R15 = frame.RegisterSet.R15?.ToHexString();
            entity.R8 = frame.RegisterSet.R8?.ToHexString();
            entity.R9 = frame.RegisterSet.R9?.ToHexString();
            entity.Rax = frame.RegisterSet.Rax?.ToHexString();
            entity.Rbp = frame.RegisterSet.Rbp?.ToHexString();
            entity.Rbx = frame.RegisterSet.Rbx?.ToHexString();
            entity.Rcx = frame.RegisterSet.Rcx?.ToHexString();
            entity.Rdi = frame.RegisterSet.Rdi?.ToHexString();
            entity.Rdx = frame.RegisterSet.Rdx?.ToHexString();
            entity.Rip = frame.RegisterSet.Rip?.ToHexString();
            entity.Rsi = frame.RegisterSet.Rsi?.ToHexString();
            entity.Rsp = frame.RegisterSet.Rsp?.ToHexString();
            entity.Ss = frame.RegisterSet.Ss?.ToHexString();
            entity.Ymm0 = frame.RegisterSet.Ymm0?.ToHexString(true);
            entity.Ymm1 = frame.RegisterSet.Ymm1?.ToHexString(true);
            entity.Ymm2 = frame.RegisterSet.Ymm2?.ToHexString(true);
            entity.Ymm3 = frame.RegisterSet.Ymm3?.ToHexString(true);
            entity.Ymm4 = frame.RegisterSet.Ymm4?.ToHexString(true);
            entity.Ymm5 = frame.RegisterSet.Ymm5?.ToHexString(true);
            entity.Ymm6 = frame.RegisterSet.Ymm6?.ToHexString(true);
            entity.Ymm7 = frame.RegisterSet.Ymm7?.ToHexString(true);
            entity.Ymm8 = frame.RegisterSet.Ymm8?.ToHexString(true);
            entity.Ymm9 = frame.RegisterSet.Ymm9?.ToHexString(true);
            entity.Ymm10 = frame.RegisterSet.Ymm10?.ToHexString(true);
            entity.Ymm11 = frame.RegisterSet.Ymm11?.ToHexString(true);
            entity.Ymm12 = frame.RegisterSet.Ymm12?.ToHexString(true);
            entity.Ymm13 = frame.RegisterSet.Ymm13?.ToHexString(true);
            entity.Ymm14 = frame.RegisterSet.Ymm14?.ToHexString(true);
            entity.Ymm15 = frame.RegisterSet.Ymm15?.ToHexString(true);
            entity.OpCode = frame.DisassemblyLine?.OpCode.ToHexString();
            entity.OpCodeMnemonic = frame.DisassemblyLine?.OpCodeMnemonic;
            entity.DisassemblyNote = frame.DisassemblyLine?.DisassemblyNote;
            entity.StackFrames = frame.StackTrace.StackFrames.Select(x => x.ToStackFrameEntity()).ToList();
            return entity;
        }

        /// <summary>
        ///     Upserts the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        public void UpsertFrames(string projectName, IEnumerable<Frame> frames)
        {
            frames = frames.ToList();
            using (var context = ContextFactory.GetContext(projectName))
            {
                foreach (var frame in frames)
                {
                    var source = ConvertFrameToEntity(frame, context);
                    var target = context.FrameEntities.FirstOrDefault(x =>
                        x.PosHi == source.PosHi && x.PosLo == source.PosLo && x.ThreadId == source.ThreadId);
                    if (target != null)
                        CopyValues(source, target);
                    else
                        context.FrameEntities.Add(source);
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    var sb = new StringBuilder();
                    var errors = e.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                        .Select(x => $"Validation Error: {x.PropertyName} - {x.ErrorMessage}");
                    sb.AppendLine($"There were validation errors when trying to persist the request:");
                    var message = String.Join(Environment.NewLine, errors);
                    sb.AppendLine(message);
                    throw new ApplicationException(sb.ToString());
                }
            }
        }

        /// <summary>
        ///     Gets the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Frame.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Frame GetFrame(string projectName, Position position, int threadId)
        {
            using (var context = ContextFactory.GetContext(projectName))
            {
                var first = context.FrameEntities.FirstOrDefault(x =>
                    x.PosHi == position.High && x.PosLo == position.Low && x.ThreadId == threadId);
                if (first == null)
                    throw new IndexOutOfRangeException(
                        $"Count not find a frame with position: {position} and threadid: {threadId}");
                return first.ToFrame();
            }
        }

        public IEnumerable<Frame> Search(string projectName, ICriterion criterion)
        {
            using (var ctx = ContextFactory.GetContext(projectName))
            {
                var query = ctx.FrameEntities.AsExpandable();
                var visitor = new FrameCriterionVisitor();
                var exp = (Expression<Func<FrameEntity, bool>>)visitor.Visit(criterion);
                var frames = query.Where(exp).ToList();
                var converted = frames.Select(x => x.ToFrame());
                return converted;
            }
        }
        
        /// <summary>
        ///     Copies the values.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        private static void CopyValues(FrameEntity source, FrameEntity target)
        {
            if (source.Rax != null)
                target.Rax = source.Rax;

            if (source.Rbx != null)
                target.Rbx = source.Rbx;

            if (source.Rcx != null)
                target.Rcx = source.Rcx;

            if (source.Rdx != null)
                target.Rdx = source.Rdx;

            if (source.Rip != null)
                target.Rip = source.Rip;

            if (source.DisassemblyNote != null)
                target.DisassemblyNote = source.DisassemblyNote;

            if (source.OpCode != null)
                target.OpCode = source.OpCode;

            if (source.OpCodeMnemonic != null)
                target.OpCodeMnemonic = source.DisassemblyNote;

            if (source.StackFrames != null)
            {
                foreach (var sourceStackFrame in source.StackFrames)
                {
                    var targetStackFrame =
                        target.StackFrames?.FirstOrDefault(x => x.StackPointer == sourceStackFrame.StackPointer);
                    if (targetStackFrame != null)
                    {
                        // copy source values to target
                        if (sourceStackFrame.ReturnAddress != null)
                            targetStackFrame.ReturnAddress = sourceStackFrame.ReturnAddress;
                        if (sourceStackFrame.ModuleName != null)
                            targetStackFrame.ModuleName = sourceStackFrame.ModuleName;
                        if (sourceStackFrame.Function != null)
                            targetStackFrame.Function = sourceStackFrame.Function;
                        if (sourceStackFrame.Offset != null)
                            targetStackFrame.Offset = sourceStackFrame.Offset;
                    }
                    else
                    {
                        target.StackFrames.Add(sourceStackFrame);
                    }
                }
            }

        }
    }
}