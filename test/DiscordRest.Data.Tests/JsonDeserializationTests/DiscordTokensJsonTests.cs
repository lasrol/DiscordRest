using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace DiscordRest.Data.Tests.JsonDeserializationTests
{
    public class DiscordTokensJsonTests
    {
        [Fact]
        public void CanReadDeserializeObject()
        {
            var json = "{\"access_token\": \"valid-access-token\", \"token_type\": \"Bearer\", \"expires_at\": \"2017-12-05T22:06:50.0000000+00:00\", \"refresh_token\": \"new-refresh-token\", \"scope\": \"identify guilds email\" }";
            var tokens = JsonConvert.DeserializeObject<DiscordTokens>(json);
            tokens.ShouldNotBeNull();
        }

        [Fact]
        public void CanReadAccessTokenAfterDeserialization()
        {
            var json = "{\"access_token\": \"valid-access-token\", \"token_type\": \"Bearer\", \"expires_at\": \"2017-12-05T22:06:50.0000000+00:00\", \"refresh_token\": \"new-refresh-token\", \"scope\": \"identify guilds email\" }";
            var tokens = JsonConvert.DeserializeObject<DiscordTokens>(json, new JsonSerializerSettings{});
            tokens.AccessToken.ShouldBe("valid-access-token");
        }

        [Fact]
        public void CanReadRefreshTokenAfterDeserialization()
        {
            var json = "{\"access_token\": \"valid-access-token\", \"token_type\": \"Bearer\", \"expires_at\": \"2017-12-05T22:06:50.0000000+00:00\", \"refresh_token\": \"new-refresh-token\", \"scope\": \"identify guilds email\" }";
            var tokens = JsonConvert.DeserializeObject<DiscordTokens>(json);
            tokens.RefreshToken.ShouldBe("new-refresh-token");
        }

        [Fact]
        public void CanReadTokenTypeAfterDeserialization()
        {
            var json = "{\"access_token\": \"valid-access-token\", \"token_type\": \"Bearer\", \"expires_at\": \"2017-12-05T22:06:50.0000000+00:00\", \"refresh_token\": \"new-refresh-token\", \"scope\": \"identify guilds email\" }";
            var tokens = JsonConvert.DeserializeObject<DiscordTokens>(json);
            tokens.TokenType.ShouldBe("Bearer");
        }

        [Fact]
        public void CanReadExpiresTimeAfterDeserialization()
        {
            var json = "{\"access_token\": \"valid-access-token\", \"token_type\": \"Bearer\", \"expires_at\": \"2017-12-05T22:06:50.0000000+00:00\", \"refresh_token\": \"new-refresh-token\", \"scope\": \"identify guilds email\" }";
            var tokens = JsonConvert.DeserializeObject<DiscordTokens>(json);
            tokens.ExpiresAt.ShouldBe(DateTime.Parse("2017-12-05T22:06:50.0000000+00:00"));
        }
    }
}
