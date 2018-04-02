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

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class SqlServerCriterionVisitor.
    /// </summary>
    /// <seealso cref="McFly.Server.ICriterionVisitor" />
    internal class SqlServerCriterionVisitor : ICriterionVisitor
    {
        /// <summary>
        ///     Visits the specified criterion.
        /// </summary>
        /// <param name="criterion">The criterion.</param>
        /// <returns>System.Object.</returns>
        public object Visit(ICriterion criterion)
        {
            return null;
        }

        /// <summary>
        ///     Visits the specified and criterion.
        /// </summary>
        /// <param name="andCriterion">The and criterion.</param>
        public void Visit(AndCriterion andCriterion)
        {
        }

        /// <summary>
        ///     Visits the specified or criterion.
        /// </summary>
        /// <param name="orCriterion">The or criterion.</param>
        public void Visit(OrCriterion orCriterion)
        {
        }

        /// <summary>
        ///     Visits the specified not criterion.
        /// </summary>
        /// <param name="notCriterion">The not criterion.</param>
        public void Visit(NotCriterion notCriterion)
        {
        }

        /// <summary>
        ///     Visits the specified register equals.
        /// </summary>
        /// <param name="registerEquals">The register equals.</param>
        /// <returns>Func&lt;FrameEntity, System.Boolean&gt;.</returns>
        public Func<FrameEntity, bool> Visit(RegisterEqualsCriterion registerEquals)
        {
            return entity => entity.Rax == 0;
        }
    }
}