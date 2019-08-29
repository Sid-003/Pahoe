﻿using System.Threading.Tasks;

namespace Pahoe.Payloads
{
    internal static class Equalizer
    {
        internal static ValueTask SendAsync(LavalinkPlayer player)
        {
            using var payloadWriter = new PayloadWriter(player);
            var writer = payloadWriter.Writer;

            payloadWriter.WriteStartPayload("equalizer");

            writer.WritePropertyName("bands");
            writer.WriteStartArray();
            var bandsSpan = player.Bands.Span;
            for (int i = 0; i < 15; i++)
            {
                writer.WriteStartObject();
                writer.WriteNumber("band", i);
                writer.WriteNumber("gain", bandsSpan[i]);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            return payloadWriter.SendAsync();
        }
    }
}