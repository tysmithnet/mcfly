// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="RegisterCriterionConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.Server.Contract;
using McFly.Server.Data.Search;
using Conv = System.Convert;

namespace McFly.Server.Search
{
    /// <summary>
    ///     Class RegisterCriterionConverter.
    /// </summary>
    /// <seealso cref="McFly.Server.Search.ISearchCriterionConverter" />
    [Export(typeof(ISearchCriterionConverter))]
    internal class RegisterCriterionConverter : ISearchCriterionConverter
    {
        /// <summary>
        ///     Determines whether this instance can convert the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns><c>true</c> if this instance can convert the specified search criterion dto; otherwise, <c>false</c>.</returns>
        public bool CanConvert(SearchCriterionDto searchCriterionDto)
        {
            return searchCriterionDto is TerminalSearchCriterionDto && Regex.IsMatch(searchCriterionDto?.Type ?? "",
                       "register", RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///     Converts the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>ICriterion.</returns>
        /// <exception cref="ArgumentException">Input has to have at least 3 arguments</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception">change this</exception>
        public ICriterion Convert(SearchCriterionDto searchCriterionDto)
        {
            var terminal = (TerminalSearchCriterionDto) searchCriterionDto;
            var args = terminal.Args;
            if (args.Length < 3)
                throw new ArgumentException("Input has to have at least 3 arguments");
            var reg = Register.Lookup(args[0]);
            if (reg == null)
                throw new ArgumentOutOfRangeException();
            switch (args[1])
            {
                case "-eq":
                    return new RegisterEqualsCriterion(reg, Conv.ToUInt64(args[2]).ToHexString());

                case "-between":
                    var low = Conv.ToUInt64(args[2]);
                    var hi = Conv.ToUInt64(args[3]); // todo: check before
                    return new RegisterBetweenCriterion(reg, low.ToHexString(), hi.ToHexString());
                default:
                    throw new Exception("change this");
            }
        }
    }
}