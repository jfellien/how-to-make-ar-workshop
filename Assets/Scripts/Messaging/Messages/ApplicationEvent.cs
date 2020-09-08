using System.Collections.Generic;
using Messaging.Listener;
using UnityEngine;

namespace Messaging.Messages
{
    [CreateAssetMenu(fileName = "New Event", menuName = "Messaging/Event", order = 0)]
    public class ApplicationEvent : ScriptableObject
    {
        private readonly List<ApplicationEventListener> _eventListeners = new List<ApplicationEventListener>();

        public void Raise()
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(ApplicationEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(ApplicationEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}