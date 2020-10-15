using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Pahoe.Payloads
{
    internal static class ConfigureResume
    {
        internal const string ResumeKey = "iLoveQuahu";

        internal static ValueTask SendAsync(ClientWebSocket webSocket)
        {
            using var payloadWriter = new PayloadWriter(webSocket);
            var writer = payloadWriter.Writer;

            payloadWriter.WriteStartPayload("configureResuming");

            writer.WriteString("key", ResumeKey);
            writer.WriteNumber("timeout", 60);

            return payloadWriter.SendAsync();
        }
    }
}
