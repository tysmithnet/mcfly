using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using McFly.Core;
using McFly.Server.Contract;
using McFly.WinDbg.Test.Builders;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class ServerClient_Should
    {
        [Fact]
        public void Add_Memory_Ranges()
        {
            // arrange
            var httpBuilder = new HttpFacadeBuilder();
            httpBuilder.WithPostAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpBuilder.WithPostJsonAsync(new HttpResponseMessage(HttpStatusCode.OK));
            var settings = new Settings
            {
                ServerUrl = "https://some.server.net",
                ProjectName = "testing"
            };
            var serverClient = new ServerClient {HttpFacade = httpBuilder.Build(), Settings = settings};

            var headers = new HttpHeaders();
            headers.Add("X-Project-Name", "testing");

            var memoryChunk = new MemoryChunk
            {
                Position = new Position(0x10, 0x0),
                MemoryRange = new MemoryRange(0x100, 0x200),
                Bytes = new byte[] {0x00, 0x11}
            };
            serverClient.AddMemoryRange(memoryChunk);
            var content = new AddMemoryRequest(memoryChunk);
            httpBuilder.Mock.Verify(
                facade => facade.PostJsonAsync(new Uri("https://some.server.net/api/memory"),
                    content, headers), Times.Once);
        }

        [Fact]
        public void Add_Tags()
        {
            // arrange
            var httpBuilder = new HttpFacadeBuilder();
            httpBuilder.WithPostAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpBuilder.WithPostJsonAsync(new HttpResponseMessage(HttpStatusCode.OK));
            var settings = new Settings
            {
                ServerUrl = "https://some.server.net",
                ProjectName = "testing"
            };
            var serverClient = new ServerClient {HttpFacade = httpBuilder.Build(), Settings = settings};

            var headers = new HttpHeaders();
            headers.Add("X-Project-Name", "testing");

            // act
            serverClient.AddTag(new Position(0xabc, 0x123), new[] {1}, new Tag());

            // assert
            httpBuilder.Mock.Verify(
                facade => facade.PostJsonAsync(new Uri("https://some.server.net/api/tag"),
                    new AddTagRequest(new Position(0xabc, 0x123), new[] {1}, new Tag()), headers), Times.Once);
        }

        [Fact]
        public void Get_Recent_Tags()
        {
            var tags = new[]
            {
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Title = "1",
                    Body = "1",
                    CreateDateUtc = DateTime.UtcNow
                }, 
            };
            // arrange
            var httpBuilder = new HttpFacadeBuilder();
            httpBuilder.WithPostAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpBuilder.WithPostJsonAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tags)))
            });

            var settings = new Settings
            {
                ServerUrl = "https://some.server.net",
                ProjectName = "testing"
            };
            var serverClient = new ServerClient {HttpFacade = httpBuilder.Build(), Settings = settings};

            var headers = new HttpHeaders();
            headers.Add("X-Project-Name", "testing");

            var response = serverClient.GetRecentTags(10);
            response.SequenceEqual(tags).Should().BeTrue();
            
            httpBuilder.Mock.Verify(
                facade => facade.PostJsonAsync(new Uri("https://some.server.net/api/tag"),
                    new RecentTagsRequest(10), headers), Times.Once);
        }

        [Fact]
        public void Search_For_Frames()
        {
            var crit = new TerminalSearchCriterionDto();
            var frames = new[]
            {
                new Frame()
                {
                    Id = Guid.NewGuid(),
                }, 
            };
            // arrange
            var httpBuilder = new HttpFacadeBuilder();
            httpBuilder.WithPostAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpBuilder.WithPostJsonAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(frames)))
            });

            var settings = new Settings
            {
                ServerUrl = "https://some.server.net",
                ProjectName = "testing"
            };
            var serverClient = new ServerClient { HttpFacade = httpBuilder.Build(), Settings = settings };

            var headers = new HttpHeaders();
            headers.Add("X-Project-Name", "testing");

            var response = serverClient.SearchFrames(crit);
            response.SequenceEqual(frames).Should().BeTrue();

            httpBuilder.Mock.Verify(
                facade => facade.PostJsonAsync(new Uri("https://some.server.net/api/search/frame"),
                    crit, headers), Times.Once);
        }

        [Fact]
        public void Initialize_Projects()
        {
            // arrange
            var httpBuilder = new HttpFacadeBuilder();
            httpBuilder.WithPostAsync(new HttpResponseMessage(HttpStatusCode.OK));
            var settings = new Settings
            {
                ServerUrl = "https://some.server.net",
                ProjectName = "testing"
            };
            var serverClient = new ServerClient {HttpFacade = httpBuilder.Build(), Settings = settings};
            var expected = new NewProjectRequest("testing", "35:0", "1000:0");

            // act
            serverClient.InitializeProject("testing", new Position(0x35, 0), new Position(0x1000, 0));

            // assert
            httpBuilder.Mock.Verify(
                f => f.PostJsonAsync(new Uri("https://some.server.net/api/project"), expected, null), Times.Once);
        }

        [Fact]
        public void Upsert_Frames()
        {
            // arrange
            var httpBuilder = new HttpFacadeBuilder();
            httpBuilder.WithPostJsonAsync(new HttpResponseMessage(HttpStatusCode.OK));
            var settings = new Settings
            {
                ServerUrl = "https://some.server.net",
                ProjectName = "testing"
            };
            var serverClient = new ServerClient {HttpFacade = httpBuilder.Build(), Settings = settings};
            var frames = MockFrames.SingleThreaded0;
            var headers = new HttpHeaders
            {
                ["X-Project-Name"] = "testing"
            };

            // act
            serverClient.UpsertFrames(frames);

            // assert
            httpBuilder.Mock.Verify(facade => facade.PostJsonAsync(new Uri("https://some.server.net/api/frame"),
                It.Is<IEnumerable<Frame>>(e => e.SequenceEqual(frames)), headers), Times.Once);
        }
    }
}