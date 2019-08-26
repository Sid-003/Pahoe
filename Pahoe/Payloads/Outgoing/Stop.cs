﻿using System.Text.Json;
using System.Threading.Tasks;

namespace Pahoe.Payloads.Outgoing
{
    internal static class Stop
    {
        internal static ValueTask SendAsync(LavalinkPlayer player)
        {
            using PayloadWriter payloadWriter = new PayloadWriter(player.Client.WebSocket);
            Utf8JsonWriter writer = payloadWriter.Writer;

            payloadWriter.WriteStartPayload("stop", player.GuildIdStr);
            writer.WriteString("guildId", player.VoiceChannel.GuildId.ToString());

            return payloadWriter.SendAsync();
        }
    }
}
