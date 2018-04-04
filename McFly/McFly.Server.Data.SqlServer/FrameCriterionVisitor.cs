// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
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
using McFly.Server.Data.Search;

using FramePredicateExpression = System.Linq.Expressions.Expression<System.Func<McFly.Server.Data.SqlServer.FrameEntity, bool>>;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class SqlServerCriterionVisitor.
    /// </summary>
    /// <seealso cref="ICriterionVisitor" />
    internal class FrameCriterionVisitor : ICriterionVisitor
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
                case RegisterEqualsCriterion equal:
                    return Visit(equal);
            }

            FramePredicateExpression identity = entity => false;
            return identity;
        }

        /// <summary>
        ///     Visits the specified and criterion.
        /// </summary>
        /// <param name="andCriterion">The and criterion.</param>
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

        public FramePredicateExpression Visit(OrCriterion orCriterion)
        {
            FramePredicateExpression result = null;
            foreach (var c in orCriterion.Criteria)
            {
                var f = (FramePredicateExpression)c.Accept(this);
                if (result == null)
                {
                    result = f;
                    continue;
                }

                result = result.Or(f);
            }

            return result;
        }

        public FramePredicateExpression Visit(RegisterEqualsCriterion registerEqualsCriterion)
        {
            var bytes = registerEqualsCriterion.Value;
            if (registerEqualsCriterion.Register == Register.Rax)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rax.SequenceEqual(bytes);
                return exp;
            }

            if (registerEqualsCriterion.Register == Register.Rbx)
            {
                FramePredicateExpression exp = entity =>
                    entity.Rbx.SequenceEqual(bytes);
                return exp;
            }

            throw new IndexOutOfRangeException("Unknown register");
        }
    }
}