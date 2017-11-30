using System;
using System.Collections.Generic;
using System.Text;
using DiscordRest.Utility;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class DiscordEndpointCollectionUtilityTests
    {
        [Fact]
        public void CanFindAllService()
        {
            var services = DiscordEndpointCollectionUtility.SearchForEndpoints();

            services.Count.ShouldBe(15);
        }

        [Fact]
        public void NoInterfaceIsNull()
        {
            var services = DiscordEndpointCollectionUtility.SearchForEndpoints();
            services.ShouldAllBe((t) => t.Key != null);
        }

        [Fact]
        public void NoImplementationTypeIsNull()
        {
            var services = DiscordEndpointCollectionUtility.SearchForEndpoints();
            services.ShouldAllBe((t) => t.Value != null); ;
        }
    }
}
