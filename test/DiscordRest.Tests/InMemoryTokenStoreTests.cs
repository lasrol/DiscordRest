using System;
using System.Collections.Generic;
using System.Text;
using DiscordRest.Data;
using DiscordRest.Models;
using DiscordRest.Utility;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class InMemoryTokenStoreTests
    {
        [Fact]
        public async void CanRetrieveSavedAccessTokenFromInMemoryStore()
        {
            //Arrange
            var token = CreateDiscordToken();
            var sut = new InMemoryTokenStore();
            await sut.SaveTokensAsync("my-id", token);

            //Act
            var result = await sut.GetAccessTokenAsync("my-id");

            //Assert
            result.ShouldBe(token.AccessToken);
        }

        [Fact]
        public async void CanRetrieveSavedRefreshTokenFromInMemoryStore()
        {
            //Arrange
            var token = CreateDiscordToken();
            var sut = new InMemoryTokenStore();
            await sut.SaveTokensAsync("my-id", token);

            //Act
            var result = await sut.GetRefreshTokenAsync("my-id");

            //Assert
            result.ShouldBe(token.RefreshToken);
        }

        [Fact]
        public async void CanRetrieveTokenExpirationFromInMemoryStore()
        {
            //Arrange
            var token = CreateDiscordToken();
            var sut = new InMemoryTokenStore();
            await sut.SaveTokensAsync("my-id", token);

            //Act
            var result = await sut.GetExpiresAtAsync("my-id");

            //Assert
            result.ShouldBe(token.ExpiresAt);
        }

        [Fact]
        public async void ShouldBeEmptyStringIfRefreshTokenIsNotSet()
        {
            //Arrange
            var sut = new InMemoryTokenStore();
            await sut.SaveTokensAsync("id", new DiscordTokens());

            //Act
            var result = await sut.GetRefreshTokenAsync("id");

            //Assert
            result.ShouldBeNullOrWhiteSpace();
        }

        [Fact]
        public async void ShouldBeEmptyStringIfRefreshTokenIsNotSetButAccessTokenIsSet()
        {
            //Arrange
            var sut = new InMemoryTokenStore();
            await sut.SaveTokensAsync("id", new DiscordTokens() { AccessToken = "some-token"});

            //Act
            var result = await sut.GetRefreshTokenAsync("id");

            //Assert
            result.ShouldBeNullOrWhiteSpace();
        }

        [Fact]
        public async void SavingTokensWithoutSpecifyingIdentityMustThrowArgumentNullException()
        {
            //Arrange
            var sut = new InMemoryTokenStore();

            //Act & //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SaveTokensAsync(string.Empty, new DiscordTokens()));
        }

        private static DiscordTokens CreateDiscordToken()
        {
            return new DiscordTokens
            {
                AccessToken = "Dqc5iuTOad",
                RefreshToken = "CKTkW9SgzP",
                ExpiresAt = DateTime.UtcNow.AddMinutes(30),
                TokenType = "Bearer"
            };
        }
    }
}
