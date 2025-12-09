using System;

namespace EventMonitor.Editor
{
    [Serializable]
    public class EventEntry
    {
        public string EventName;
        public string EventType;
        public string SenderName;
        public object Payload;
        public DateTime Timestamp;
        public double DurationMs;

        public int Count = 1;
    }
}