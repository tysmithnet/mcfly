// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-16-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="FromProjectNameHeaderAttribute.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Headers
{
    /// <summary>
    ///     Convenience attribute that indicates the project name is in the header under the key "X-Project-Name"
    /// </summary>
    /// <seealso cref="McFly.Server.Headers.FromHeaderAttribute" />
    public class FromProjectNameHeaderAttribute : FromHeaderAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FromProjectNameHeaderAttribute" /> class.
        /// </summary>
        /// <param name="headerName">Name of the header.</param>
        public FromProjectNameHeaderAttribute(string headerName = null) : base("X-Project-Name")
        {
        }
    }
}