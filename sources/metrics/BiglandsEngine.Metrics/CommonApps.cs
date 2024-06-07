using System;

namespace BiglandsEngine.Metrics
{
    /// <summary>
    /// Identifiers for common apps.
    /// </summary>
    public static class CommonApps
    {
        /// <summary>
        /// The BiglandsEngine launcher application identifier
        /// </summary>
        public static readonly MetricAppId BiglandsEngineLauncherAppId =
            new MetricAppId(new Guid("B3149460-226D-4877-9E54-057308847969"), "BiglandsEngineLauncher");

        /// <summary>
        /// The BiglandsEngine editor application identifier
        /// </summary>
        public static readonly MetricAppId BiglandsEngineEditorAppId =
            new MetricAppId(new Guid("BD1F1188-9ED7-410C-8080-F4E0A698DE2A"), "BiglandsEngineEditor");
    }
}