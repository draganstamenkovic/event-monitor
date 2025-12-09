using EventMonitor.Editor;
using UnityEngine;
using UnityEngine.UI;

namespace EventMonitor.Samples
{
    public class ExampleEventSender : MonoBehaviour
    {
        [SerializeField] private Button raiseEventButton;

        private void OnEnable()
        {
            raiseEventButton.onClick.AddListener(RaiseExampleEvent);
        }
        
        private void OnDisable()
        {
            raiseEventButton.onClick.RemoveListener(RaiseExampleEvent);
        }

        private void RaiseExampleEvent()
        {
            EventTracker.LogEvent("ExampleButtonPressed", this);
        }
    }
}