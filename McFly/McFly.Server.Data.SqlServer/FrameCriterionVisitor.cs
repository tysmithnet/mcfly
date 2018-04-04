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
using System.Linq.Expressions;
using McFly.Core;
using McFly.Server.Data.Search;

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

            Expression<Func<FrameEntity, bool>> identity = entity => false;
            return identity;
        }

        /// <summary>
        ///     Visits the specified and criterion.
        /// </summary>
        /// <param name="andCriterion">The and criterion.</param>
        public Expression Visit(AndCriterion andCriterion)
        {
            Expression result = null;
            foreach (var c in andCriterion.Criteria)
            {
                var f = (Expression) c.Accept(this);
                if (result == null)
                {
                    result = f;
                    continue;
                }

                result = Expression.AndAlso(result, f);
            }

            return result;
        }

        public Expression Visit(OrCriterion orCriterion)
        {
            Expression result = null;
            foreach (var c in orCriterion.Criteria)
            {
                var f = (Expression) c.Accept(this);
                if (result == null)
                {
                    result = f;
                    continue;
                }

                result = Expression.OrElse(result, f);
            }

            return result;
        }

        public Expression Visit(RegisterEqualsCriterion registerEqualsCriterion)
        {
            if (registerEqualsCriterion.Register == Register.Rax)
            {
                Expression<Func<FrameEntity, bool>> exp = entity => entity.Rax == registerEqualsCriterion.Value.ToLong();
                return exp.Body;
            }

            if (registerEqualsCriterion.Register == Register.Rbx)
            {
                Expression<Func<FrameEntity, bool>> exp = entity => entity.Rbx == registerEqualsCriterion.Value.ToLong();
                return exp.Body;
            }

            throw new IndexOutOfRangeException("Unknown register");
        }
    }
}