using System.Threading.Tasks;
using EliteAPI.Abstractions;
using Microsoft.Extensions.Logging;

namespace TemplateProject
{
    // Core class of our application
    public class Core
    {
        private readonly IEliteDangerousApi _api;
        private readonly ILogger<Core> _log;

        public Core(ILogger<Core> log, IEliteDangerousApi api)
        {
            // Get our dependencies through dependency injection
            _log = log;
            _api = api;
        }

        public async Task Run()
        {
            // Log whenever we change the landing gear
            _api.Ship.Gear.OnChange += (sender, isDeployed) =>
            {
                _log.LogInformation(isDeployed ? "Landing gear deployed" : "Landing gear retracted");
            };

            // Log whenever we dock at a station
            _api.Events.DockedEvent += (sender, e) =>
            {
                _log.LogInformation($"Docked at {e.StationName} in {e.StarSystem}");
            };

            // Start EliteAPI
            await _api.StartAsync();
        }
    }
}
