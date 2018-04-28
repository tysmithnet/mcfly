using System;
using System.IO;
using FluentAssertions;
using McFly.WinDbg;
using Newtonsoft.Json;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class SettingsJsonConverter_Should
    {
        [Fact]
        public void Not_Implement_ReadJson()
        {
            var sut = new SettingsJsonConverter();
            Action a = () => sut.ReadJson(null, null, null, false, null);
            a.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public void Write_Json_For_All_Settings()
        {
            var settings = new ISettings[] {new MockSettingsA(), new MockSettingsB()};
            var sut = new SettingsJsonConverter();
            using (var tw = new StringWriter())
            using (var jw = new JsonTextWriter(tw))
            {
                sut.WriteJson(jw, settings, null);
                tw.ToString().Should()
                    .Be("{\"McFly.Test.MockSettingsA\":{\"A\":null},\"McFly.Test.MockSettingsB\":{\"B\":null}}");
            }
        }
    }

    public class MockSettingsA : ISettings
    {
        public string A { get; set; }
    }

    public class MockSettingsB : ISettings
    {
        public string B { get; set; }
    }
}