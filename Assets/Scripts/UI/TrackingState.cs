using System;
using TMPro;
using UnityEngine;
using Variables;

namespace UI
{
    public class TrackingState : MonoBehaviour
    {
        private const string TRACKING_IS_ACTIVE = "Tracking is active";
        private const string TRACKING_IS_INACTIVE = "Tracking is inactive";
        [SerializeField] private BoolVariable trackingIsActive;
        [SerializeField] private TMP_Text statusText;
        private void Update()
        {
            if (trackingIsActive.IsTrue() 
                && statusText.text != TRACKING_IS_ACTIVE)
            {
                statusText.text = TRACKING_IS_ACTIVE;
            }
            
            if (trackingIsActive.IsFalse() 
                && statusText.text != TRACKING_IS_INACTIVE)
            {
                statusText.text = TRACKING_IS_INACTIVE;
            }
        }
    }
}