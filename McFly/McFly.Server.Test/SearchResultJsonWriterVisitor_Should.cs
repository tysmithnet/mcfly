using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace McFly.Server.Test
{
    public class SearchResultJsonWriterVisitor_Should
    {
        [Fact]
        public void Create_The_Correct_Json_Basic()
        {
            var visitor = new SearchResultJsonWriterVisitor();

            var searchRequest = new SearchRequest
            {
                Index = "frame",
                Criterion = new TerminalCriterion()
                {
                    Type = "register",
                    Expression = "rax -eq 1"
                }
            };

            var json = visitor.ConvertToJson(searchRequest);
            json.Should().Be(@"{
  ""Type"": ""register"",
  ""Expression"": ""rax -eq 1""
}");
        }
    }
}
