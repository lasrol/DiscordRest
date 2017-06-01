using DiscordRest.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DiscordRest.Configuration;
using Xunit;
using Shouldly;

namespace DiscordRest.Tests
{
    public class HttpConnectionBuilderTests
    {
        [Fact]
        public void CanInstanciateAHttpConnectionWithoutAnyConfiguration()
        {
            //Arrange
            var sut = new HttpConnectionBuilder();

            //Act
            var result = sut.Build(null);

            //Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void ThrowsIfClientIdIsUndefinedAndUsingBasicAuthentication()
        {
            //Arrange
            var sut = new HttpConnectionBuilder(new HttpConnectionOptions
            {
                ClientSecret = "very-secret"
            });

            //Act & //Assert
            Assert.ThrowsAny<Exception>(() => sut.Build(DiscordConstants.AuthenticationSchemes.Basic));
        }

        [Fact]
        public void ThrowsIfClientSecretIsUndefinedAndUsingBasicAuthentication()
        {
            //Arrange
            var sut = new HttpConnectionBuilder(new HttpConnectionOptions
            {
                ClientId = "my-id"
            });

            //Act & //Assert
            Assert.ThrowsAny<Exception>(() => sut.Build(DiscordConstants.AuthenticationSchemes.Basic));
        }
    }
}
