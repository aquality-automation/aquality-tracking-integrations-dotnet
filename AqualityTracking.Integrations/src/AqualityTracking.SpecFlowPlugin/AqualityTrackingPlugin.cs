using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: RuntimePlugin(typeof(AqualityTracking.SpecFlowPlugin.AqualityTrackingPlugin))]

namespace AqualityTracking.SpecFlowPlugin
{
    public class AqualityTrackingPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            // Add SpecFlow customizations
        }
    }
}
