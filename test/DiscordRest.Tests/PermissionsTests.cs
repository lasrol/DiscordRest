using DiscordRest.Data;
using Shouldly;
using Xunit;

namespace DiscordRest.Tests
{
    public class PermissionsTests
    {
        [Fact]
        public void CanAddOnePermission()
        {

            var sut = new Permissions(0)
            {
                IsAdmin = true
            };

            sut.RawValue.ShouldBe((ulong)8);
        }

        [Fact]
        public void CanAddMultiplePermission()
        {

            var sut = new Permissions(0)
            {
                IsAdmin = true,
                IsManager = true
            };

            sut.RawValue.ShouldBe((ulong)40);
        }

        [Fact]
        public void CanReadAdministratorValue()
        {
            var sut = new Permissions(40);

            sut.IsAdmin.ShouldBeTrue();
        }
    }
}
