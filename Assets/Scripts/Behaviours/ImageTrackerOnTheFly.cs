using System;
using System.Collections;
using System.IO;
using easyar;
using Messaging.Messages;
using UnityEngine;

namespace Behaviours
{
    public class ImageTrackerOnTheFly : MonoBehaviour
    {
        [SerializeField, Tooltip("Component which is tracking images added by a ImageTargetController")]
        private ImageTrackerFrameFilter imageTargetTracker;

        [SerializeField, Tooltip("Model which will spawn on top of taken Screenshot")]
        private GameObject trackingProjection;

        [Header("Events")] 
        [SerializeField, Tooltip("Event which will raise when a Screenshot was taken")]
        private ApplicationStringEvent screenshotWasTaken;

        public void TakeScreenshot()
        {
            var screenshotsPath = GetScreenshotsPath();

            StartCoroutine(TakeAndSaveScreenshot(screenshotsPath));
        }
        
        public void StartTrackingForImage(string imageFilePath)
        {
            var targetName = Guid.NewGuid().ToString();
            var imageTarget = new GameObject(targetName);
            
            // Das imageTarget benötigt einen ImageController
            // Am Controller werden die Parameter für das Tracking gesetzt
            //var controller = ...

            //controller.SourceType = ...
            //controller.ImageFileSource.PathType = ...
            //controller.ImageFileSource.Path = ...
            //controller.ImageFileSource.Name = ...
            //controller.Tracker = ...

            AddProjection(imageTarget);
        }

        private static string GetScreenshotsPath()
        {
            var screenshotsPath = Path.Combine(Application.persistentDataPath, "Screenshots");

            if (!Directory.Exists(screenshotsPath))
                Directory.CreateDirectory(screenshotsPath);

            return screenshotsPath;
        }

        private IEnumerator TakeAndSaveScreenshot(string screenshotsPath)
        {
            yield return new WaitForEndOfFrame();

            var screenshot = ReadPixelsFromScreen();

            SaveScreenshot(screenshotsPath, screenshot);

            // Event auslösen, dass der Screenshot gemacht wurde. Als Parameter den ScreenshotFilePath übergeben
        }
        
        private static byte[] ReadPixelsFromScreen()
        {
            var screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            screenshot.Apply();

            var data = screenshot.EncodeToJPG(100);
            Destroy(screenshot);
            return data;
        }

        private static void SaveScreenshot(string screenshotsPath, byte[] screenshot)
        {
            var screenshotName = $"photo{DateTime.Now.Ticks}.jpg";
            var screenshotFilePath = Path.Combine(screenshotsPath, screenshotName);

            File.WriteAllBytes(screenshotFilePath, screenshot);
        }
        
        private void AddProjection(GameObject imageTarget)
        {
            // An Position 0,0,0 soll eine Projektion erstellt werden,
            // die senkrecht auf dem Screenshot erscheint
            // Die Projektion ist ein Kindelement vom ImageTarget
        }
    }
}