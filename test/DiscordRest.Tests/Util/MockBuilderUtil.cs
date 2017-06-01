using System;
using System.Collections.Generic;
using System.Net.Http;
using DiscordRest.Configuration;
using DiscordRest.Utility;
using Moq;

namespace DiscordRest.Tests.Util
{
    public static class MockBuilderUtil { 
        public static IHttpConnectionBuilder CreateConnectionBuilderMock(Func<HttpResponseMessage> returnMessage)
        {
            var mock = new Mock<HttpConnectionBuilder>();
            mock.CallBase = true;
            mock.Setup(p => p.Build(It.IsAny<string>())).Returns(CreateConnectionMock(returnMessage));
            return mock.Object;
        }

        public static IHttpConnection CreateConnectionMock(Func<HttpResponseMessage> returnMessage)
        {
            var mock = new Mock<IHttpConnection>();
            mock.Setup(p => p.RunAsync())
                .ReturnsAsync(returnMessage);
            return mock.Object;
        }
    }
}