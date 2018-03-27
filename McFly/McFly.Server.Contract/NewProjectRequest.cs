// ***********************************************************************
// Assembly         : McFly.Server.Contract
// Author           : @tysmithnet
// Created          : 03-25-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-25-2018
// ***********************************************************************
// <copyright file="NewProjectRequest.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;

namespace McFly.Server.Contract
{
    /// <summary>
    ///     Class NewProjectRequest.
    /// </summary>
    /// <seealso cref="System.IEquatable{McFly.Server.Contract.NewProjectRequest}" />
    [ExcludeFromCodeCoverage]
    public class NewProjectRequest : IEquatable<NewProjectRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NewProjectRequest" /> class.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="startingPosition">The starting position.</param>
        /// <param name="endingPosition">The ending position.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     projectName
        ///     or
        ///     startingPosition
        ///     or
        ///     endingPosition
        /// </exception>
        public NewProjectRequest(string projectName, string startingPosition, string endingPosition)
        {
            ProjectName = projectName ?? throw new ArgumentNullException(nameof(projectName));
            StartingPosition = startingPosition ?? throw new ArgumentNullException(nameof(startingPosition));
            EndingPosition = endingPosition ?? throw new ArgumentNullException(nameof(endingPosition));
        }

        /// <summary>
        ///     Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        public string ProjectName { get; set; }

        /// <summary>
        ///     Gets or sets the starting position.
        /// </summary>
        /// <value>The starting position.</value>
        public string StartingPosition { get; set; }

        /// <summary>
        ///     Gets or sets the ending position.
        /// </summary>
        /// <value>The ending position.</value>
        public string EndingPosition { get; set; }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(NewProjectRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ProjectName, other.ProjectName) &&
                   string.Equals(StartingPosition, other.StartingPosition) &&
                   string.Equals(EndingPosition, other.EndingPosition);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((NewProjectRequest) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ProjectName != null ? ProjectName.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (StartingPosition != null ? StartingPosition.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EndingPosition != null ? EndingPosition.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(NewProjectRequest left, NewProjectRequest right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(NewProjectRequest left, NewProjectRequest right)
        {
            return !Equals(left, right);
        }
    }
}