// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-18-2018
// ***********************************************************************
// <copyright file="SqlServerCriterionVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq.Expressions;
using LinqKit;
using McFly.Core.Registers;
using McFly.Server.Data.Search;
using FramePredicateExpression =
    System.Linq.Expressions.Expression<System.Func<McFly.Server.Data.SqlServer.FrameEntity, bool>>;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Search criterion visitor that can create frame predicates
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.ICriterionVisitor" />
    /// <seealso cref="ICriterionVisitor" />
    internal class
        FrameCriterionVisitor : ICriterionVisitor
    {
        /// <summary>
        ///     Visits the specified criterion.
        /// </summary>
        /// <param name="criterion">The criterion.</param>
        /// <returns>System.Object.</returns>
        public object Visit(ICriterion criterion)
        {
            switch (criterion)
            {
                case AndCriterion and:
                    return Visit(and);
                case OrCriterion or:
                    return Visit(or);
                case NotCriterion not:
                    return Visit(not);
                case RegisterEqualsCriterion equal:
                    return Visit(equal);
                case RegisterBetweenCriterion between:
                    return Visit(between);
            }

            FramePredicateExpression identity = entity => true;
            return identity;
        }

        /// <summary>
        ///     Visits the specified register between criterion.
        /// </summary>
        /// <param name="registerBetweenCriterion">The register between criterion.</param>
        /// <returns>FramePredicateExpression.</returns>
        public FramePredicateExpression Visit(RegisterBetweenCriterion registerBetweenCriterion)
        {
            if (registerBetweenCriterion.Register == Register.Rax)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rax, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rax, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) <
                    0;
                return exp;
            }

            if (registerBetweenCriterion.Register == Register.Rbx)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rbx, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rbx, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) <
                    0;
                return exp;
            }

            if (registerBetweenCriterion.Register == Register.Rcx)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rcx, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rcx, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) <
                    0;
                return exp;
            }

            if (registerBetweenCriterion.Register == Register.Rdx)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rdx, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rdx, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) <
                    0;
                return exp;
            }

            /*
             * todo: PRIORITY FIX
             */

            FramePredicateExpression ret = entity => false;
            return ret;
        }

        /// <summary>
        ///     Visits the specified not criterion.
        /// </summary>
        /// <param name="notCriterion">The not criterion.</param>
        /// <returns>FramePredicateExpression.</returns>
        public FramePredicateExpression Visit(NotCriterion notCriterion)
        {
            var exp = (FramePredicateExpression) notCriterion.Criterion.Accept(this);
            var candidateExpr = exp.Parameters[0];
            var body = Expression.Not(exp.Body);

            return Expression.Lambda<Func<FrameEntity, bool>>(body, candidateExpr);
        }

        /// <summary>
        ///     Visits the specified and criterion.
        /// </summary>
        /// <param name="andCriterion">The and criterion.</param>
        /// <returns>FramePredicateExpression.</returns>
        public FramePredicateExpression Visit(AndCriterion andCriterion)
        {
            FramePredicateExpression result = null;
            foreach (var c in andCriterion.Criteria)
            {
                var f = (FramePredicateExpression) c.Accept(this);
                if (result == null)
                {
                    result = f;
                    continue;
                }

                result = result.And(f);
            }

            return result;
        }

        /// <summary>
        ///     Visits the specified or criterion.
        /// </summary>
        /// <param name="orCriterion">The or criterion.</param>
        /// <returns>FramePredicateExpression.</returns>
        public FramePredicateExpression Visit(OrCriterion orCriterion)
        {
            FramePredicateExpression result = null;
            foreach (var c in orCriterion.Criteria)
            {
                var f = (FramePredicateExpression) c.Accept(this);
                if (result == null)
                {
                    result = f;
                    continue;
                }

                result = result.Or(f);
            }

            return result;
        }

        /// <summary>
        ///     Visits the specified register equals criterion.
        /// </summary>
        /// <param name="registerEqualsCriterion">The register equals criterion.</param>
        /// <returns>FramePredicateExpression.</returns>
        /// <exception cref="IndexOutOfRangeException">Unknown register</exception>
        public FramePredicateExpression Visit(RegisterEqualsCriterion registerEqualsCriterion)
        {
            var bytes = registerEqualsCriterion.HexString;
            if (registerEqualsCriterion.Register == Register.Rax)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rax == null && bytes == null || entity.Rax != null && entity.Rax == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rcx)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rcx == null && bytes == null || entity.Rcx != null && entity.Rcx == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rdx)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rdx == null && bytes == null || entity.Rdx != null && entity.Rdx == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rbx)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rbx == null && bytes == null || entity.Rbx != null && entity.Rbx == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rsp)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rsp == null && bytes == null || entity.Rsp != null && entity.Rsp == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rbp)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rbp == null && bytes == null || entity.Rbp != null && entity.Rbp == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rsi)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rsi == null && bytes == null || entity.Rsi != null && entity.Rsi == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rdi)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rdi == null && bytes == null || entity.Rdi != null && entity.Rdi == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R8)
            {
                FramePredicateExpression exp = entity =>
                    entity.R8 == null && bytes == null || entity.R8 != null && entity.R8 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R9)
            {
                FramePredicateExpression exp = entity =>
                    entity.R9 == null && bytes == null || entity.R9 != null && entity.R9 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R10)
            {
                FramePredicateExpression exp = entity =>
                    entity.R10 == null && bytes == null || entity.R10 != null && entity.R10 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R11)
            {
                FramePredicateExpression exp = entity =>
                    entity.R11 == null && bytes == null || entity.R11 != null && entity.R11 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R12)
            {
                FramePredicateExpression exp = entity =>
                    entity.R12 == null && bytes == null || entity.R12 != null && entity.R12 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R13)
            {
                FramePredicateExpression exp = entity =>
                    entity.R13 == null && bytes == null || entity.R13 != null && entity.R13 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R14)
            {
                FramePredicateExpression exp = entity =>
                    entity.R14 == null && bytes == null || entity.R14 != null && entity.R14 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.R15)
            {
                FramePredicateExpression exp = entity =>
                    entity.R15 == null && bytes == null || entity.R15 != null && entity.R15 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Rip)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rip == null && bytes == null || entity.Rip != null && entity.Rip == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Efl)
            {
                FramePredicateExpression exp = entity =>
                    entity.Efl == null && bytes == null || entity.Efl != null && entity.Efl == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Cs)
            {
                FramePredicateExpression exp = entity =>
                    entity.Cs == null && bytes == null || entity.Cs != null && entity.Cs == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ds)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ds == null && bytes == null || entity.Ds != null && entity.Ds == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Es)
            {
                FramePredicateExpression exp = entity =>
                    entity.Es == null && bytes == null || entity.Es != null && entity.Es == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fs)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fs == null && bytes == null || entity.Fs != null && entity.Fs == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Gs)
            {
                FramePredicateExpression exp = entity =>
                    entity.Gs == null && bytes == null || entity.Gs != null && entity.Gs == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ss)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ss == null && bytes == null || entity.Ss != null && entity.Ss == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Dr0)
            {
                FramePredicateExpression exp = entity =>
                    entity.Dr0 == null && bytes == null || entity.Dr0 != null && entity.Dr0 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Dr1)
            {
                FramePredicateExpression exp = entity =>
                    entity.Dr1 == null && bytes == null || entity.Dr1 != null && entity.Dr1 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Dr2)
            {
                FramePredicateExpression exp = entity =>
                    entity.Dr2 == null && bytes == null || entity.Dr2 != null && entity.Dr2 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Dr3)
            {
                FramePredicateExpression exp = entity =>
                    entity.Dr3 == null && bytes == null || entity.Dr3 != null && entity.Dr3 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Dr6)
            {
                FramePredicateExpression exp = entity =>
                    entity.Dr6 == null && bytes == null || entity.Dr6 != null && entity.Dr6 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Dr7)
            {
                FramePredicateExpression exp = entity =>
                    entity.Dr7 == null && bytes == null || entity.Dr7 != null && entity.Dr7 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fpcw)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fpcw == null && bytes == null || entity.Fpcw != null && entity.Fpcw == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fpsw)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fpsw == null && bytes == null || entity.Fpsw != null && entity.Fpsw == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fptw)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fptw == null && bytes == null || entity.Fptw != null && entity.Fptw == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St0)
            {
                FramePredicateExpression exp = entity =>
                    entity.St0 == null && bytes == null || entity.St0 != null && entity.St0 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St1)
            {
                FramePredicateExpression exp = entity =>
                    entity.St1 == null && bytes == null || entity.St1 != null && entity.St1 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St2)
            {
                FramePredicateExpression exp = entity =>
                    entity.St2 == null && bytes == null || entity.St2 != null && entity.St2 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St3)
            {
                FramePredicateExpression exp = entity =>
                    entity.St3 == null && bytes == null || entity.St3 != null && entity.St3 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St4)
            {
                FramePredicateExpression exp = entity =>
                    entity.St4 == null && bytes == null || entity.St4 != null && entity.St4 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St5)
            {
                FramePredicateExpression exp = entity =>
                    entity.St5 == null && bytes == null || entity.St5 != null && entity.St5 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St6)
            {
                FramePredicateExpression exp = entity =>
                    entity.St6 == null && bytes == null || entity.St6 != null && entity.St6 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.St7)
            {
                FramePredicateExpression exp = entity =>
                    entity.St7 == null && bytes == null || entity.St7 != null && entity.St7 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm0)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm0 == null && bytes == null || entity.Mm0 != null && entity.Mm0 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm1)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm1 == null && bytes == null || entity.Mm1 != null && entity.Mm1 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm2)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm2 == null && bytes == null || entity.Mm2 != null && entity.Mm2 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm3)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm3 == null && bytes == null || entity.Mm3 != null && entity.Mm3 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm4)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm4 == null && bytes == null || entity.Mm4 != null && entity.Mm4 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm5)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm5 == null && bytes == null || entity.Mm5 != null && entity.Mm5 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm6)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm6 == null && bytes == null || entity.Mm6 != null && entity.Mm6 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mm7)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mm7 == null && bytes == null || entity.Mm7 != null && entity.Mm7 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Mxcsr)
            {
                FramePredicateExpression exp = entity =>
                    entity.Mxcsr == null && bytes == null || entity.Mxcsr != null && entity.Mxcsr == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm0)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm0 == null && bytes == null || entity.Ymm0 != null && entity.Ymm0 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm1)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm1 == null && bytes == null || entity.Ymm1 != null && entity.Ymm1 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm2)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm2 == null && bytes == null || entity.Ymm2 != null && entity.Ymm2 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm3)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm3 == null && bytes == null || entity.Ymm3 != null && entity.Ymm3 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm4)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm4 == null && bytes == null || entity.Ymm4 != null && entity.Ymm4 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm5)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm5 == null && bytes == null || entity.Ymm5 != null && entity.Ymm5 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm6)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm6 == null && bytes == null || entity.Ymm6 != null && entity.Ymm6 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm7)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm7 == null && bytes == null || entity.Ymm7 != null && entity.Ymm7 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm8)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm8 == null && bytes == null || entity.Ymm8 != null && entity.Ymm8 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm9)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm9 == null && bytes == null || entity.Ymm9 != null && entity.Ymm9 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm10)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm10 == null && bytes == null || entity.Ymm10 != null && entity.Ymm10 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm11)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm11 == null && bytes == null || entity.Ymm11 != null && entity.Ymm11 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm12)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm12 == null && bytes == null || entity.Ymm12 != null && entity.Ymm12 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm13)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm13 == null && bytes == null || entity.Ymm13 != null && entity.Ymm13 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm14)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm14 == null && bytes == null || entity.Ymm14 != null && entity.Ymm14 == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Ymm15)
            {
                FramePredicateExpression exp = entity =>
                    entity.Ymm15 == null && bytes == null || entity.Ymm15 != null && entity.Ymm15 == bytes;
                return exp;
            }

            if (registerEqualsCriterion.Register == Register.Exfrom)
            {
                FramePredicateExpression exp = entity =>
                    entity.Exfrom == null && bytes == null || entity.Exfrom != null && entity.Exfrom == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Exto)
            {
                FramePredicateExpression exp = entity =>
                    entity.Exto == null && bytes == null || entity.Exto != null && entity.Exto == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Brfrom)
            {
                FramePredicateExpression exp = entity =>
                    entity.Brfrom == null && bytes == null || entity.Brfrom != null && entity.Brfrom == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Brto)
            {
                FramePredicateExpression exp = entity =>
                    entity.Brto == null && bytes == null || entity.Brto != null && entity.Brto == bytes;
                return exp;
            }

            if (registerEqualsCriterion.Register == Register.Fopcode)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fopcode == null && bytes == null || entity.Fopcode != null && entity.Fopcode == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fpip)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fpip == null && bytes == null || entity.Fpip != null && entity.Fpip == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fpipsel)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fpipsel == null && bytes == null || entity.Fpipsel != null && entity.Fpipsel == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fpdp)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fpdp == null && bytes == null || entity.Fpdp != null && entity.Fpdp == bytes;
                return exp;
            }
            if (registerEqualsCriterion.Register == Register.Fpdpsel)
            {
                FramePredicateExpression exp = entity =>
                    entity.Fpdpsel == null && bytes == null || entity.Fpdpsel != null && entity.Fpdpsel == bytes;
                return exp;
            }
            throw new ArgumentOutOfRangeException(nameof(registerEqualsCriterion), $"Register provided was ${registerEqualsCriterion.Register.Name}, but that is not allowed");    
        }
    }
}