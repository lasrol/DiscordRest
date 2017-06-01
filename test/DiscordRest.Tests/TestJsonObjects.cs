using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DiscordRest.Tests
{
    public static class TestJsonObjects
    {
        public const string User = @"
        {
            ""id"": ""80351110224678912"",
            ""username"": ""Nelly"",
            ""discriminator"": ""1337"",
            ""avatar"": ""8342729096ea3675442027381ff50dfe"",
            ""verified"": true,
            ""email"": ""nelly@discordapp.com""
        }";

        public static string ValidTokenRequestResponse(string accessToken, string refreshToken) => $"{{\"access_token\": \"{accessToken}\", \"token_type\": \"Bearer\", \"expires_in\": 604800, \"refresh_token\": \"{refreshToken}\", \"scope\": \"identify guilds email\" }}";
    }
}
