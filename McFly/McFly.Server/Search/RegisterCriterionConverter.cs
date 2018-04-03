using System;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Server.Contract;
using McFly.Server.Data.Search;
using Conv = System.Convert;

namespace McFly.Server.Search
{
    [Export(typeof(ISearchCriterionConverter))]
    internal class RegisterCriterionConverter : ISearchCriterionConverter
    {
        public bool CanConvert(SearchCriterionDto searchCriterionDto)
        {
            return searchCriterionDto is TerminalSearchCriterionDto && Regex.IsMatch(searchCriterionDto?.Type ?? "",
                       "register", RegexOptions.IgnoreCase);
        }

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
                    return new RegisterEqualsCriterion(reg, Conv.ToUInt64(args[2]));
                case "-between":
                    var low = Conv.ToUInt64(args[2]);
                    var hi = Conv.ToUInt64(args[3]); // todo: check before
                    return new RegisterBetweenCriterion(reg, low, hi);
                default:
                    throw new Exception("change this");
            }
        }
    }
}