namespace EventMonitor.Runtime
{
    public interface IEventBus
    {
		void Publish(string eventName, object sender, object payload = null);
        void Subscribe(string eventName, Action<object, object> callback);
        void Unsubscribe(string eventName, Action<object, object> callback);
    }
}