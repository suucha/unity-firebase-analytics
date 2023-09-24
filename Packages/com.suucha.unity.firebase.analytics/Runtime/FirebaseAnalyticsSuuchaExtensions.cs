using Firebase;
using SuuchaStudio.Unity.Core;
using System;
using Firebase.Analytics;
using System.Collections.Generic;

namespace SuuchaStudio.Unity.LogEvents.Firebase.Analytics
{
    public static class FirebaseAnalyticsSuuchaExtensions
    {
        public static Suucha InitFirebase(this Suucha suucha)
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

                    // Set the user's sign up method.
                    FirebaseAnalytics.SetUserProperty(
                      FirebaseAnalytics.UserPropertySignUpMethod,
                      "Google");
                    // Set the user ID.
                    if (!string.IsNullOrEmpty(suucha.CustomerUserId))
                    {
                        FirebaseAnalytics.SetUserId(suucha.CustomerUserId);
                    }
                    else
                    {

                        suucha.OnCustomerUserIdChanged += OnCustomerUserIdChanged;
                        if (!string.IsNullOrEmpty(suucha.CustomerUserId))
                        {
                            FirebaseAnalytics.SetUserId(suucha.CustomerUserId);
                        }
                    }

                    // Set default session duration values.
                    FirebaseAnalytics.SetSessionTimeoutDuration(new TimeSpan(0, 30, 0));
                }
                else
                {
                    UnityEngine.Debug.LogError(
                      "Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
            return suucha;

        }

        private static void OnCustomerUserIdChanged(string oldId, string newId)
        {
            FirebaseAnalytics.SetUserId(newId);
        }
        private static bool firebaseAnalyticsLogEventAdded = false;
        private static FirebaseAnalyticsLogEventReporter reporter;
        public static FirebaseAnalyticsLogEventReporter InitFirebaseAnalyticsReporter(this Suucha suucha,
            List<string> allowedEventNames = null,
            List<string> excludedEventNames = null,
            Dictionary<string, string> eventNameMap = null,
            Dictionary<string, string> eventParameterNameMap = null)
        {
            if (!firebaseAnalyticsLogEventAdded)
            {
                reporter = new FirebaseAnalyticsLogEventReporter(allowedEventNames,
                    excludedEventNames, 
                    eventNameMap,
                    eventParameterNameMap);
                firebaseAnalyticsLogEventAdded = true;
            }
            return reporter;
        }

    }
}
