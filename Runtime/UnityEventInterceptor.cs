namespace EventMonitor.Runtime
{
    public static class UnityEventInterceptor
    {
        public static void Intercept(string eventName, object sender, UnityEvent unityEvent)
        {
            EventTracker.LogEvent(eventName, sender, "UnityEvent");
            unityEvent?.Invoke();
        }

        public static void Intercept<T>(string eventName, object sender, UnityEvent<T> unityEvent, T arg)
        {
            EventTracker.LogEvent(eventName, sender, "UnityEvent", arg);
            unityEvent?.Invoke(arg);
        }
    }
}