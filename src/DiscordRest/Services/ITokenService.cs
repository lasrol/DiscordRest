using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Models;

namespace DiscordRest.Services
{
    /// <summary>
    /// Service used to handle tokens
    /// </summary>
    public interface ITokenService
    {
        Task RenewTokensAsync(string refreshToken);
    }
}
