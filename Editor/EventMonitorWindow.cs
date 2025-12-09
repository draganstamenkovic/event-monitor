using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace EventMonitor.Editor
{
    public class EventMonitorWindow : EditorWindow
    {
        private readonly List<EventEntry> _entries = new();
        private Vector2 _scroll;

        [MenuItem("Window/Diagnostics/Event Monitor")]
        public static void Open()
        {
            GetWindow<EventMonitorWindow>("Event Monitor");
        }

        private void OnEnable()
        {
            EventTracker.OnEventLogged += OnEventLogged;
        }

        private void OnDisable()
        {
            EventTracker.OnEventLogged -= OnEventLogged;
        }

        private void OnEventLogged(EventEntry entry)
        {
            _entries.Add(entry);
            Repaint();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Real-Time Event Monitor", EditorStyles.boldLabel);
            EditorGUILayout.Space(5);

            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            foreach (var e in _entries)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField($"🟢 {e.EventName}", EditorStyles.boldLabel);

                EditorGUILayout.LabelField("Type:", e.EventType);
                EditorGUILayout.LabelField("Sender:", e.SenderName);
                EditorGUILayout.LabelField("Time:", e.Timestamp.ToString("HH:mm:ss.fff"));
                EditorGUILayout.LabelField("Count:", e.Count.ToString());
                EditorGUILayout.LabelField("Duration (ms):", e.DurationMs.ToString("F3"));

                if (e.Payload != null)
                    EditorGUILayout.LabelField("Payload:", e.Payload.ToString());

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space(5);
            }

            EditorGUILayout.EndScrollView();
        }
    }
}