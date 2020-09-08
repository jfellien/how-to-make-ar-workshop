using Messaging.Messages;
using Messaging.UnityEvents;
using UnityEngine;

namespace Messaging.Listener
{
    public class ApplicationStringEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public ApplicationStringEvent @event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityStringEvent response;

        private void OnEnable()
        {
            if (@event != null)
            {
                @event.RegisterListener(this);
            }
            else
            {
                Debug.LogWarning($"No @event assigned to { name }.{nameof(ApplicationStringEventListener)}");
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
                Debug.LogWarning($"No @event assigned to { name }.{nameof(ApplicationStringEventListener)}");
            }
        }

        public void OnEventRaised(string payload)
        {
            if (response != null)
            {
                response.Invoke(payload);
            }
            else
            {
                Debug.LogWarning($"No response assigned to { name }.{nameof(ApplicationEventListener)}");
            }
        }
    }
}