using System.Threading.Tasks;
using Grpc.Core;

namespace ClientComms
{
    public class CommsClient
    {
        public string GetVersion()
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new CommsService.CommsServiceClient(channel);
            var versionReply = client.GetVersion(new GetVersionRequest());
            return versionReply.Version;
        }

        public async Task<string> GetVersionAsync()
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new CommsService.CommsServiceClient(channel);
            var versionReply = await client.GetVersionAsync(new GetVersionRequest());
            return versionReply.Version;
        }
    }
}
