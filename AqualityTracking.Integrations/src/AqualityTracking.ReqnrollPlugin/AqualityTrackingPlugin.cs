using Reqnroll.Plugins;
using Reqnroll.UnitTestProvider;

[assembly: RuntimePlugin(typeof(AqualityTracking.ReqnrollPlugin.AqualityTrackingPlugin))]

namespace AqualityTracking.ReqnrollPlugin
{
    public class AqualityTrackingPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            // Add Reqnroll customizations
        }
    }
}
