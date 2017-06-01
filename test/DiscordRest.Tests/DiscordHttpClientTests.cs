using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;
using DiscordRest.Services.Implementations;
using DiscordRest.Tests.Util;
using DiscordRest.Utility;
using Moq;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class DiscordHttpClientTests
    {

        [Fact]
        public async void CanParseValidResponse()
        {
            //Arrange
            var sut = new DiscordHttpClient(MockBuilderUtil.CreateConnectionBuilderMock(() => {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(TestJsonObjects.User)
                };
            }), null, null, null);
            
            //Act
            var result = await sut.RunAsync<DiscordUser>(HttpMethod.Get, "/user/@me", null);

            //Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task UnauthorizedExceptionsShouldTryToRenewTokenAndRetryQueryAsync()
        {
            //Arrange
            var user = "me";

            var okResponse =
                new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(TestJsonObjects.User) };

            var mockHttpConnection = new Mock<IHttpConnection>();
            mockHttpConnection.SetupSequence(p => p.RunAsync())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Unauthorized))
                .ReturnsAsync(okResponse)
                .ReturnsAsync(okResponse);

            var mockConnectionBuilder = new Mock<HttpConnectionBuilder> { CallBase = true };
            mockConnectionBuilder.Setup(p => p.Build(It.IsAny<string>())).Returns(mockHttpConnection.Object);

            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync(user, new DiscordTokens
            {
                AccessToken = "invalid-access-token",
                RefreshToken = "valid-token"
            });

            var sut = new DiscordHttpClient(mockConnectionBuilder.Object, store, new TokenService(mockConnectionBuilder.Object, store), new CurrentUserContext(user));

            //Act
            var result = await sut.RunAsync<DiscordUser>(HttpMethod.Get, "/user/@me", null);
            result.ShouldNotBeNull();
        }
    }
}
