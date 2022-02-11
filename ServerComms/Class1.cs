using System.Threading.Tasks;
using Grpc.Core;

namespace ServerComms
{
    public class CommsServiceImpl : CommsService.CommsServiceBase
    {
        public override Task<GetVersionReply> GetVersion(GetVersionRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetVersionReply {Version = "0.0.0.0"});
        }
    }
}
