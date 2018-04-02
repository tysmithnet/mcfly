using System;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Server.Data.Search;

namespace McFly.Server.Controllers
{
    [Export(typeof(ISearchCriterionConverter))]
    internal abstract class RegisterCriterionConverter : BaseSearchCriterionConverter
    {
        public override bool CanConvert(string conversionType)
        {
            return Regex.IsMatch(conversionType ?? "", "register", RegexOptions.IgnoreCase);
        }

        public override ICriterion Convert(string conversionType, string input)
        {
            var args = CommandLineToArgs(input);
            if(args.Length != 3)
                throw new ArgumentException("Input has to have 3 arguments");
            var reg = Register.Lookup(args[0]);
            if(reg == null)
                throw new ArgumentOutOfRangeException();
            switch (args[1])
            {
                case "-eq":
                    return new RegisterEqualsCriterion(reg, System.Convert.ToUInt64(input[2]));
                default:
                    throw new Exception("change this");
            }
        }
    }
}