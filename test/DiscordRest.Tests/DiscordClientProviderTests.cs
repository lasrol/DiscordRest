using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class DiscordClientProviderTests
    {
        [Fact]
        public void CanGetClientFromFactory()
        {
            var result = DiscordClientProvider.Create();
            result.ShouldNotBeNull();
        }
    }
}
