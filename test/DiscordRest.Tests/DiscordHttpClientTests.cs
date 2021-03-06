﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Endpoints.Implementations;
using DiscordRest.Models;
using DiscordRest.Tests.Util;
using DiscordRest.Utility;
using Microsoft.Extensions.Logging;
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
            var tokenStoreMock = new Mock<ITokenStore>();
            tokenStoreMock.Setup(p => p.GetAccessTokenAsync(It.IsAny<string>()))
                .ReturnsAsync(() => "some-valid-token");
            tokenStoreMock.Setup(p => p.GetExpiresAtAsync(It.IsAny<string>()))
                .ReturnsAsync(() => DateTime.UtcNow.AddDays(2));

            var sut = new DiscordHttpClient(MockBuilderUtil.CreateConnectionBuilderMock(() => {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(TestJsonObjects.User)
                };
            }), tokenStoreMock.Object, null, new CurrentUserContext("me"));
            
            //Act
            var result = await sut.RunAsync<DiscordUser>(HttpMethod.Get, "/user/@me", null);

            //Assert
            result.ShouldNotBeNull();
        }


        [Fact]
        public async Task ExpiredTokenShouldRenewTokenBeforeRunningRequest()
        {
            var user = "me";
            var store = new InMemoryTokenStore();
            await store.SaveTokensAsync(user, new DiscordTokens
            {
                AccessToken = "invalid-access-token",
                RefreshToken = "valid-token",
                ExpiresAt = DateTime.UtcNow.AddMinutes(-30)
            });

            var mockHttpConnection = new Mock<IHttpConnection>();
            mockHttpConnection.Setup(p => p.RunAsync())
                .ReturnsAsync(() => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(TestJsonObjects.ValidTokenRequestResponse("valid-access-token", "valid-refresh-token")) });
            var mockConnectionBuilder = new Mock<HttpConnectionBuilder> { CallBase = true };
            mockConnectionBuilder.Setup(p => p.Build(It.IsAny<string>())).Returns(mockHttpConnection.Object);

            var sut = new DiscordHttpClient(mockConnectionBuilder.Object, store, new TokenEndpoint(mockConnectionBuilder.Object, store, new Mock<ILogger<TokenEndpoint>>().Object), new CurrentUserContext(user));

            //Act
            var result = await sut.RunAsync<DiscordUser>(HttpMethod.Get, "/user/@me", null);

            //Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task ServiceResultShouldBeFauilureForAnyFailureResponseCode()
        {
            //Arrange
            var tokenStoreMock = new Mock<ITokenStore>();
            tokenStoreMock.Setup(p => p.GetAccessTokenAsync(It.IsAny<string>()))
                .ReturnsAsync(() => "some-valid-token");
            tokenStoreMock.Setup(p => p.GetExpiresAtAsync(It.IsAny<string>()))
                .ReturnsAsync(() => DateTime.UtcNow.AddDays(2));

            var sut = new DiscordHttpClient(MockBuilderUtil.CreateConnectionBuilderMock(() =>
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }), tokenStoreMock.Object, null, new CurrentUserContext("me"));

            //Act
            var result = await sut.RunAsync(HttpMethod.Delete, $"/some-service-endpoint", null);

            //Assert
            result.Succeeded.ShouldBeFalse();
        }

        [Fact]
        public async Task ServiceResultShouldBeSuccessFor204NoContentResponse()
        {
            //Arrange
            var tokenStoreMock = new Mock<ITokenStore>();
            tokenStoreMock.Setup(p => p.GetAccessTokenAsync(It.IsAny<string>()))
                .ReturnsAsync(() => "some-valid-token");

            tokenStoreMock.Setup(p => p.GetExpiresAtAsync(It.IsAny<string>()))
                .ReturnsAsync(() => DateTime.UtcNow.AddDays(2));

            var sut = new DiscordHttpClient(MockBuilderUtil.CreateConnectionBuilderMock(() =>
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }), tokenStoreMock.Object, null, new CurrentUserContext("me"));

            //Act
            var result = await sut.RunAsync(HttpMethod.Delete, $"/some-service-endpoint", null);

            //Assert
            result.Succeeded.ShouldBeTrue();
        }
    }
}
    