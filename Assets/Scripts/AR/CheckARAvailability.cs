using System;
using System.Collections;
using Messaging.Messages;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Variables;

namespace AR
{
    public class CheckARAvailability : MonoBehaviour
    {
        [Header("Variables")] 
        [SerializeField] private BoolVariable trackingIsActive;
        [Header("Messaging")]
        [SerializeField] private ApplicationEvent arIsAvailable;

        private ARSession _arSession;

        private void Awake()
        {
            _arSession = GetComponent<ARSession>();
            trackingIsActive.Set(false);

            if (_arSession == null)
            {
                throw new ApplicationException("This script have to added to an ARSession object.");
            }
        }

        IEnumerator Start()
        {
#if UNITY_EDITOR
        
            _arSession.enabled = true;
        
            arIsAvailable?.Raise();
            trackingIsActive.Set(true);

            yield return null;
#else
        return Check();
#endif
        }

        private IEnumerator Check()
        {
            if ((ARSession.state == ARSessionState.None) ||
                (ARSession.state == ARSessionState.CheckingAvailability))
            {
                yield return ARSession.CheckAvailability();
            }

            if (ARSession.state == ARSessionState.Unsupported)
            {
                // Start some fallback experience for unsupported devices
                _arSession.enabled = false;
            }
            else
            {
                // Start the AR session
                _arSession.enabled = true;
            
                arIsAvailable?.Raise();
                trackingIsActive.Set(true);
            }
        }
    }
}
