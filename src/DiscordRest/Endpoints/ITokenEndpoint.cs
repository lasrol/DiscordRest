using System.Threading.Tasks;

namespace DiscordRest.Endpoints
{
    /// <summary>
    /// Service used to handle tokens
    /// </summary>
    public interface ITokenEndpoint
    {
        Task RenewTokensAsync(string refreshToken);
    }
}
