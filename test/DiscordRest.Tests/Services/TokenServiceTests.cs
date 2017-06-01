using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Exceptions;
using DiscordRest.Models;
using DiscordRest.Services.Implementations;
using DiscordRest.Tests.Util;
using DiscordRest.Utility;
using Moq;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests.Services
{
    public class TokenServiceTests
    {
        [Fact]
        public async Task ThrowsExceptionIfNoRefreshTokenCanBeFoundAsync()
        {
            //Arrange
            var mockConnectionBuilder = new Mock<HttpConnectionBuilder> { CallBase = true };
            var connectionBuilder = mockConnectionBuilder.Object;

            var sut = new TokenService(connectionBuilder, new InMemoryTokenStore());
            //Act & //Assert
            await Assert.ThrowsAsync(typeof(InvalidTokenException), () =>
            {
                return sut.RenewTokensAsync(Guid.Empty.ToString());
            });
        }

        [Fact]
        public async void CanRenewTokensWithRefreshToken()
        {
            //Arrange
            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync("me", new DiscordTokens() { RefreshToken = "some-secret-refresh-token" });
            var sut = new TokenService(MockBuilderUtil.CreateConnectionBuilderMock(() => new HttpResponseMessage(HttpStatusCode.OK) { Content = _validTokenRequestResponse("some-valid-access-token", "some-valid-refresh-token") }), store);

            //Act
            await sut.RenewTokensAsync("me");
        }

        [Fact]
        public async void FailedRenewedTokenShouldThrowException()
        {
            //Arrange
            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync("me", new DiscordTokens() { RefreshToken = "invalid-refresh-token" });
            var sut = new TokenService(MockBuilderUtil.CreateConnectionBuilderMock(() => new HttpResponseMessage(HttpStatusCode.Unauthorized)), store);

            //Act & //Assert
            await Assert.ThrowsAnyAsync<UnauthorizedAccessException>(() =>
            {
                return sut.RenewTokensAsync("me");
            });
        }

        [Fact]
        public async void ThrowExceptionIfCurrentUserCantBeFound()
        {
            //Arrange
            var mockConnectionBuilder = new Mock<HttpConnectionBuilder> { CallBase = true };
            var connectionBuilder = mockConnectionBuilder.Object;

            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync("not-me", new DiscordTokens());

            var sut = new TokenService(connectionBuilder, store);
            //Act & //Assert
            await Assert.ThrowsAsync(typeof(InvalidTokenException), () =>
            {
                return sut.RenewTokensAsync("me");
            });
        }

        [Fact]
        public async void ThrowExceptionIfAccessTokenIsNullAfterRenew()
        {
            //Arrange
            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync("me", new DiscordTokens() { RefreshToken = "some-valid-token" });

            var sut = new TokenService(MockBuilderUtil.CreateConnectionBuilderMock(() => new HttpResponseMessage(HttpStatusCode.OK) { Content = _validTokenRequestResponse("", "some-valid-refreshtoken") }), store);
            //Act & //Assert
            await Assert.ThrowsAsync(typeof(InvalidTokenException), () =>
            {
                return sut.RenewTokensAsync("me");
            });
        }

        [Fact]
        public async void ThrowExceptionIfRefreshTokenIsNullAfterRenew()
        {
            //Arrange
            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync("me", new DiscordTokens() { RefreshToken = "some-valid-token" });

            var sut = new TokenService(MockBuilderUtil.CreateConnectionBuilderMock(() => new HttpResponseMessage(HttpStatusCode.OK) { Content = _validTokenRequestResponse("some-valid-access-token", "") }), store);
            //Act & //Assert
            await Assert.ThrowsAsync(typeof(InvalidTokenException), () =>
            {
                return sut.RenewTokensAsync("me");
            });
        }

        private StringContent _validTokenRequestResponse(string accessToken, string refreshToken) => new StringContent(
            $"{{\"access_token\": \"{accessToken}\", \"token_type\": \"Bearer\", \"expires_in\": 604800, \"refresh_token\": \"{refreshToken}\", \"scope\": \"identify guilds email\" }}");
    }
}
