using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace McFly.Core.JsonConverters.Test
{
    public class PositionJsonConverter_Should
    {
        [Fact]
        public void Read_Json_Correctly()
        {
            var sut = new PositionJsonConverter();
            var json = "{\"Low\":2147483647,\"High\":2147483647}";
            using (var tr = new StringReader(json))
            using (var jr = new JsonTextReader(tr))
            {
                var position = sut.ReadJson(jr, typeof(Position), new Position(0, 0), true, null);
                position.High.Should().Be(int.MaxValue);
                position.Low.Should().Be(int.MaxValue);
            }

            using (var tr = new StringReader(json))
            using (var jr = new JsonTextReader(tr))
            {
                var position = sut.ReadJson(jr, typeof(Position), new Position(0, 0), false, null);
                position.High.Should().Be(int.MaxValue);
                position.Low.Should().Be(int.MaxValue);
            }
        }

        [Fact]
        public void Write_Correct_Json()
        {
            var sut = new PositionJsonConverter();
            using (var tw = new StringWriter())
            using (var jw = new JsonTextWriter(tw))
            {
                sut.WriteJson(jw, new Position(int.MaxValue, int.MaxValue), null);
                tw.ToString().Should()
                    .Be("{\"Low\":2147483647,\"High\":2147483647}");

            }
        }
    }
}