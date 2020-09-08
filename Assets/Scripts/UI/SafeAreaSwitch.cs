using System;
using UnityEngine;

namespace UI
{
    public class SafeAreaSwitch : MonoBehaviour
    {
        [SerializeField] KeyCode KeySafeArea = KeyCode.A;
        SafeArea.SimDevice[] Sims;
        private BlockArea.SimDevice[] Blocks;
        int SimIdx;

        void Awake ()
        {
            if (!Application.isEditor)
                Destroy (gameObject);

            Sims = (SafeArea.SimDevice[])Enum.GetValues (typeof (SafeArea.SimDevice));
            Blocks = (BlockArea.SimDevice[])Enum.GetValues (typeof (BlockArea.SimDevice));
        }

        void Update ()
        {
            if (Input.GetKeyDown (KeySafeArea))
                ToggleSafeArea ();
        }

        /// <summary>
        /// Toggle the safe area simulation device.
        /// </summary>
        void ToggleSafeArea ()
        {
            SimIdx++;

            if (SimIdx >= Sims.Length)
                SimIdx = 0;

            SafeArea.Sim = Sims[SimIdx];
            BlockArea.Sim = Blocks[SimIdx];
        }
    }
}