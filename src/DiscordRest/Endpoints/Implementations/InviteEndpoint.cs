using System;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Endpoints.Implementations
{
    public class InviteEndpoint : IInviteEndpoint
    {
        public Task<Invite> Accept(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Invite> Delete(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Invite> Get(string code)
        {
            throw new NotImplementedException();
        }
    }
}
