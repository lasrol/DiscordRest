using DiscordRest.Extensions;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void StringIsEqualBecauseItHasSlashPrefix()
        {
            var input = "/test";

            var result = input.EnsureSlashPrefixed();

            result.ShouldBe(input);
        }

        [Fact]
        public void SlashIsAppendedToInputBecauseNoSlashIsPresent()
        {
            var input = "test";

            var result = input.EnsureSlashPrefixed();

            result.ShouldBe("/" + input);
        }

        [Theory]
        [InlineData("http://google.com")]
        [InlineData("https://google.com")]
        [InlineData("http://google.com/search")]
        [InlineData("https://google.com/search")]
        public void ShouldBeValidUrls(string input)
        {
            var result = input.IsValidHttpUrl();
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData("ws://google.com")]
        [InlineData("://google.com")]
        [InlineData("google.com/search")]
        public void ShouldBeInvalidUrls(string input)
        {
            var result = input.IsValidHttpUrl();
            result.ShouldBeFalse();
        }
    }
}
