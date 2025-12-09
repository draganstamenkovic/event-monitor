using System;
using System.Collections.Generic;

namespace EventMonitor.Editor
{
    public static class EventTracker
    {
        public static event Action<EventEntry> OnEventLogged;

        private static readonly Dictionary<string, EventEntry> _latestEntries = new();

        public static void LogEvent(
            string eventName, 
            object sender, 
            string eventType = "C# Event",
            object payload = null)
        {
            var start = DateTime.Now;

            var entry = new EventEntry
            {
                EventName = eventName,
                EventType = eventType,
                SenderName = sender?.ToString() ?? "Unknown",
                Payload = payload,
                Timestamp = DateTime.Now
            };

            if (_latestEntries.TryGetValue(eventName, out var existing))
            {
                existing.Count++;
                entry.Count = existing.Count;
            }
            else
            {
                _latestEntries[eventName] = entry;
            }

            entry.DurationMs = (DateTime.Now - start).TotalMilliseconds;

            OnEventLogged?.Invoke(entry);
        }
    }
}