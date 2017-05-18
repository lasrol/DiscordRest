using Shouldly;
using Xunit;

namespace DiscordRest.Data.Tests
{
    public class PermissionsTest
    {
        [Theory]
        [InlineData(36953089)]
        [InlineData(66321471)]
        public void ReturnsSamePermissionsBecauseNoChange(ulong input)
        {
            var permissions = new Permissions(input);

            permissions.RawValue.ShouldBe(input);
        }
    }
}
