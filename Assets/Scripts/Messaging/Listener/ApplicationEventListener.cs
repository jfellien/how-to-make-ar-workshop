using Messaging.Messages;
using UnityEngine;
using UnityEngine.Events;

namespace Messaging.Listener
{
    public class ApplicationEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public ApplicationEvent @event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent response;

        private void OnEnable()
        {
            if (@event != null)
            {
                @event.RegisterListener(this);
            }
            else
            {
                Debug.LogWarning($"No @event assigned to { name }.{nameof(ApplicationEventListener)}");
            }
        }

        private void OnDisable()
        {
            if (@event != null)
            {
                @event.UnregisterListener(this);
            }
            else
            {
                Debug.LogWarning($"No @event assigned to { name }.{nameof(ApplicationEventListener)}");
            }
        }

        public void OnEventRaised()
        {
            if (response != null)
            {
                response.Invoke();
            }
            else
            {
                Debug.LogWarning($"No response assigned to { name }.{nameof(ApplicationEventListener)}");
            }
        }
    }
}