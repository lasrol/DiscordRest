using System;
using System.Collections.Generic;
using System.Text;
using DiscordRest.Attributes;
using DiscordRest.Extensions;
using DiscordRest.Tests.Fake;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void CanReadAttributeOnType()
        {
            //Arrange

            //Act
            var result = typeof(TestClassWithAttribute).GetAttribute<EndpointAttribute>();

            //Assert
            result.Url.ToString().ShouldBe("/some/url");
        }
    }
}
