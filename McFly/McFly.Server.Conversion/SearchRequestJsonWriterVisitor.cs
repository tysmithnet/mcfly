// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="SearchResultJsonWriterVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Conversion
{
    /// <summary>
    ///     Json converter for search request criterion
    /// </summary>
    /// <seealso cref="McFly.Server.Contract.ISearchRequestVisitor" />
    internal class SearchRequestJsonWriterVisitor : ISearchRequestVisitor
    {
        /// <summary>
        ///     Converts to j object.
        /// </summary>
        /// <param name="searchRequest">The search request.</param>
        /// <returns>JObject.</returns>
        public JObject ConvertToJObject(SearchCriterionDto searchRequest)
        {
            var o = (JObject) Visit(searchRequest);
            return o;
        }

        /// <summary>
        ///    Converts the search request to JSON
        /// </summary>
        /// <param name="searchRequest">The search request.</param>
        /// <returns>System.String.</returns>
        public string ConvertToJson(SearchCriterionDto searchRequest)
        {
            return ConvertToJObject(searchRequest).ToString(Formatting.Indented);
        }

        /// <summary>
        ///     Visits the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>System.Object.</returns>
        public object Visit(SearchCriterionDto searchCriterionDto)
        {
            if (searchCriterionDto is TerminalSearchCriterionDto terminal)
                return Visit(terminal);
            var o = new JObject {{"Type", searchCriterionDto.Type}};
            var childObjects = searchCriterionDto.SubCriteria.Select(c => c.Accept(this)).Cast<JObject>().ToArray();
            var arr = new JArray(childObjects);
            o.Add("SubCriteria", arr);
            return o;
        }

        /// <summary>
        ///     Visits the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>System.Object.</returns>
        public object Visit(TerminalSearchCriterionDto searchCriterionDto)
        {
            var o = new JObject
            {
                {"Type", searchCriterionDto.Type},
                {"Args", new JArray(searchCriterionDto.Args)}
            };
            return o;
        }
    }
}