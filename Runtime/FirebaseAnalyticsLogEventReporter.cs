using Firebase.Analytics;
using System.Collections.Generic;
using SuuchaStudio.Unity.Core.LogEvents;
using Cysharp.Threading.Tasks;

namespace SuuchaStudio.Unity.LogEvents.Firebase.Analytics
{
    public class FirebaseAnalyticsLogEventReporter : LogEventReporterAbstract
    {
        public override string Name => "FirebaseAnalytics";
        public FirebaseAnalyticsLogEventReporter():base()
        {

        }
        public FirebaseAnalyticsLogEventReporter(List<string> allowedEventNames,
            List<string> excludedEventNames,
            Dictionary<string, string> eventNameMap,
            Dictionary<string, string> eventParameterNameMap)
            :base(allowedEventNames, excludedEventNames,eventNameMap, eventParameterNameMap)
        {

        }

        protected override UniTask LogEventInternal(string name, Dictionary<string, string> eventParameters)
        {
            FirebaseAnalytics.LogEvent(name, ToParameters(eventParameters));
            return UniTask.CompletedTask;
        }

        private Parameter[] ToParameters(Dictionary<string, string> eventParameters)
        {
            var parameters = new List<Parameter>();
            foreach(var key in eventParameters.Keys)
            {
                parameters.Add(new Parameter(key, eventParameters[key]));
            }
            return parameters.ToArray();
        }
    }
}
