using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EliteAPI.Event.Attributes;
using EliteAPI.Event.Models;
using EliteAPI.Event.Module;
using Microsoft.Extensions.Logging;

namespace TemplateProject.Modules
{
    public class ChatModule : EliteDangerousEventModule
    {
        private readonly ILogger<ChatModule> _log;

        /// <inheritdoc />
        public ChatModule(IEliteDangerousApi api, ILogger<ChatModule> log) : base(api)
        {
            _log = log;
        }
        
        [EliteDangerousEvent]
        public void OnReceived(ReceiveTextEvent e)
        {
            _log.LogInformation($"Received text from {e.From}: '{e.MessageLocalised}'");
        }

        [EliteDangerousEvent]
        public void OnSend(SendTextEvent e)
        {
            _log.LogInformation($"Sent text to {e.To}: '{e.Message}'");
        }
    }
}
