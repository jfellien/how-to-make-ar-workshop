using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Behaviours
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceObject : MonoBehaviour
    {
        //[SerializeField] 
        //[Tooltip("The object which will placed on a plane at touched position.")]
        // private ... wir brauchen ein GameObject, das an der Stelle angezeigt wird, wo das Display berührt wurde.
        
        /// <summary>
        /// Manager who detects touch positions on planes
        /// </summary>
        private ARRaycastManager _raycastManager;
        
        void Awake()
        {
            // Raycast Manager zuweisen
            // _raycastManager = ...
        }
        
        // Diese Funktion wird vor jedem Frame ausgeführt
        void Update()
        {
            // Wenn das Display nicht berührt wurde, dann die Funtion verlassen
            if (Touched() == false) return;
            
            // Touchpoint vom Input geben lassen
            var touch = GetTouchPoint();
            
            // Falls der Touch vorbei ist, angefangen hat oder noch bewegt, dann abbrechen 
            if (Began(touch) == false)
            {
                return;
            }

            // Position des Touches geben lassen und verwenden
            if (TryGetPoseOnDisplay(touch, out Pose poseOnDisplay))
            {
                // Nächste Zeile wieder aktivieren, wenn das placedPrefab als Parameter gesetzt wurde
                // Instantiate(placedPrefab, poseOnDisplay.position, poseOnDisplay.rotation);
            }
        }

        private bool Touched()
        {
            // Ersetze mit: Wenn Input.touchCount kleiner gleich 0 ist
            return false;
        }

        private Touch GetTouchPoint()
        {
            // Ersetze mit: Gib mir den Touchpoint vom Display;
            return new Touch();
        }

        private bool Began(Touch touch)
        {
            // Ersetzen mit: Touch muss Began sein 
            return false;
        }

        private bool TryGetPoseOnDisplay(Touch touch, out Pose poseOnDisplay)
        {
            // Diese Funktion ist vollständig
            
            var hitPoints = new List<ARRaycastHit>();
            
            // Mit Hilfe des RayCastManagers wird die Position im Raum ermittelt, wo man das Display berührt hat
            if (_raycastManager.Raycast(touch.position, hitPoints, TrackableType.PlaneWithinPolygon) == false)
            {
                poseOnDisplay = Pose.identity;
                return false;
            }
            
            // Die erste Pose in der liste der HitPoints ist die oberste (sichtbare) Ebene
            poseOnDisplay = hitPoints[0].pose;
            return true;
        }
    }
}