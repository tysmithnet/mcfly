using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace McFly.Core.JsonConverters.Test
{
    public class MemoryRangeJsonConverter_Should
    {
        [Fact]
        public void Read_Json_Correctly()
        {
            var sut = new MemoryRangeJsonConverter();
            var json = "{\"LowAddress\":18446744073709551615,\"HighAddress\":18446744073709551615}";
            using (var tr = new StringReader(json))
            using (var jr = new JsonTextReader(tr))
            {
                var memoryRange = sut.ReadJson(jr, typeof(MemoryRange), new MemoryRange(0, 0), true, null);
                memoryRange.HighAddress.Should().Be(ulong.MaxValue);
                memoryRange.LowAddress.Should().Be(ulong.MaxValue);
            }

            using (var tr = new StringReader(json))
            using (var jr = new JsonTextReader(tr))
            {
                var memoryRange = sut.ReadJson(jr, typeof(MemoryRange), new MemoryRange(0, 0), false, null);
                memoryRange.HighAddress.Should().Be(ulong.MaxValue);
                memoryRange.LowAddress.Should().Be(ulong.MaxValue);
            }
        }

        [Fact]
        public void Write_Correct_Json()
        {
            var sut = new MemoryRangeJsonConverter();
            using (var tw = new StringWriter())
            using (var jw = new JsonTextWriter(tw))
            {
                sut.WriteJson(jw, new MemoryRange(ulong.MaxValue, ulong.MaxValue), null);
                tw.ToString().Should()
                    .Be("{\"LowAddress\":18446744073709551615,\"HighAddress\":18446744073709551615}");

            }
        }
    }
}