namespace EventMonitor.Runtime
{
    public class EventBus : IEventBus
    {
		private readonly Dictionary<string, List<Action<object, object>>> _listeners = new();

        public event Action<string, object, object> OnEventPublished;

        public void Publish(string eventName, object sender, object payload = null)
        {
            OnEventPublished?.Invoke(eventName, sender, payload);

            if (!_listeners.TryGetValue(eventName, out var list))
                return;

            foreach (var callback in list)
                callback.Invoke(sender, payload);
        }

        public void Subscribe(string eventName, Action<object, object> callback)
        {
            if (!_listeners.ContainsKey(eventName))
                _listeners[eventName] = new();
            _listeners[eventName].Add(callback);
        }

        public void Unsubscribe(string eventName, Action<object, object> callback)
        {
            if (_listeners.TryGetValue(eventName, out var list))
                list.Remove(callback);
        }
    }
}