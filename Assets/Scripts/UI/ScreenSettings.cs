using System;
using UnityEngine;

namespace UI
{
    public class ScreenSettings : MonoBehaviour
    {
        [SerializeField] [Tooltip("Enables or disables Screen Rotation Lock")]
        private bool allowScreenRotation;

        private void Start()
        {
            Screen.autorotateToPortrait = allowScreenRotation;
            Screen.autorotateToLandscapeLeft = allowScreenRotation;
            Screen.autorotateToLandscapeRight = allowScreenRotation;
            Screen.autorotateToPortraitUpsideDown = allowScreenRotation;
        }
    }
}