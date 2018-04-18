// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="SqlServerCriterionVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using McFly.Core;
using McFly.Core.Registers;
using McFly.Server.Data.Search;
using FramePredicateExpression =
    System.Linq.Expressions.Expression<System.Func<McFly.Server.Data.SqlServer.FrameEntity, bool>>;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class SqlServerCriterionVisitor.
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

        public FramePredicateExpression Visit(RegisterBetweenCriterion registerBetweenCriterion)
        {
            if (registerBetweenCriterion.Register == Register.Rax)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rax, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rax, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) < 0;
                return exp;
            }
            if (registerBetweenCriterion.Register == Register.Rbx)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rbx, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rbx, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) < 0;
                return exp;
            }
            if (registerBetweenCriterion.Register == Register.Rcx)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rcx, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rcx, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) < 0;
                return exp;
            }
            if (registerBetweenCriterion.Register == Register.Rdx)
            {
                FramePredicateExpression exp = entity =>
                    string.Compare(entity.Rdx, registerBetweenCriterion.Low, StringComparison.OrdinalIgnoreCase) >= 0
                    && string.Compare(entity.Rdx, registerBetweenCriterion.High, StringComparison.OrdinalIgnoreCase) < 0;
                return exp;
            }
            FramePredicateExpression ret = entity => false;
            return ret;
        }

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
                    (entity.Rax == null && bytes == null) || (entity.Rax != null && entity.Rax == bytes);
                return exp;
            }

            if (registerEqualsCriterion.Register == Register.Rbx)
            {
                FramePredicateExpression exp = entity =>
                    (entity.Rbx == null && bytes == null) || (entity.Rbx != null && entity.Rbx == bytes);
                return exp;
            }

            throw new IndexOutOfRangeException("Unknown register");
        }
    }
}                                                 