using System;
using System.Collections;
using easyar;
using Messaging.Messages;
using UnityEngine;
using Variables;

namespace Behaviours
{
    public class CheckForARAvailability : MonoBehaviour
    {
        [SerializeField] private ApplicationEvent arIsAvailable;
        [SerializeField] private BoolVariable trackingIsActive;
        private void Start()
        {
            trackingIsActive.Set(false);
            
            StartCoroutine(Check());
        }

        private IEnumerator Check()
        {
            yield return new WaitUntil(() => EasyARController.Initialized);
            
            Debug.Log("[>>>>>> APP <<<<<<<] EasyAR is ready for tracking");
            
            arIsAvailable.Raise();
            trackingIsActive.Set(true);
        }
    }
}