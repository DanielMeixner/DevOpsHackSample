using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using PartsUnlimited.Telemetry;
using PartsUnlimited.WebsiteConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsUnlimitedWebsite.Telemetry
{
    public class ApplicationInsightsTelemetryProvider : ITelemetryProvider
    {
        
        private readonly TelemetryClient _telemetry;

        public ApplicationInsightsTelemetryProvider(IApplicationInsightsSettings aiSettings)
        {
            TelemetryConfiguration telemetryConfiguration = new TelemetryConfiguration
            {
                TelemetryInitializers = { new VersionedTelemetryInitializer() }
            };

            _telemetry = new TelemetryClient(telemetryConfiguration);
         //   _telemetry.InstrumentationKey = Configuration.GetSection(ConfigurationPath.Combine("Keys", "ApplicationInsights"));


        }
       

        public void TrackTrace(string message)
        {
            _telemetry.TrackTrace(message);
        }

        public void TrackEvent(string message)
        {
            _telemetry.TrackEvent(message);
        }

        public void TrackEvent(string message, Dictionary<string, string> properties, Dictionary<string, double> measurements)
        {
            _telemetry.TrackEvent(message, properties, measurements);
        }

        public void TrackException(Exception exception)
        {
            _telemetry.TrackException(exception);
        }
    }
}
