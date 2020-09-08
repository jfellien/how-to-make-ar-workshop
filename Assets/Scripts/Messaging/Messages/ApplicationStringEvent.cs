using System.Collections.Generic;
using Messaging.Listener;
using UnityEngine;

namespace Messaging.Messages
{
    [CreateAssetMenu(fileName = "New String Event", menuName = "Messaging/String Event", order = 0)]
    public class ApplicationStringEvent : ScriptableObject
    {
        private readonly List<ApplicationStringEventListener> _eventListeners = new List<ApplicationStringEventListener>();

        public void Raise(string payload)
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(payload);
        }

        public void RegisterListener(ApplicationStringEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(ApplicationStringEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}