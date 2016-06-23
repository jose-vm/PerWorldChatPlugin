using MiNET;
using MiNET.Net;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

namespace PerWorldChat
{
    public class Main : Plugin
    {
        [PacketHandler, Receive]
        public Package OnMessageSent(McpeText message, Player player)
        {
            string text = message.message;

            if (text.StartsWith("/") || text.StartsWith("."))
            {
                return message;
            }

            text = TextUtils.RemoveFormatting(text);
            player.Level.BroadcastMessage(text, type: MessageType.Raw);
            return null;
        }
    }
}
