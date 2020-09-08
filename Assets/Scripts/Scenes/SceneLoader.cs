using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        public void AddScene(string sceneName)
        {
            StartCoroutine(AddSceneAsync(sceneName));
        }
        
        public IEnumerator AddSceneAsync(string sceneName)
        {
            if (SceneAlreadyLoaded(sceneName) == false)
            {
                yield return SceneManager.LoadSceneAsync($"Scenes/{sceneName}", LoadSceneMode.Additive);
            }
        }

        private bool SceneAlreadyLoaded(string sceneName)
        {
            for (var sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
            {
                if (SceneManager.GetSceneAt(sceneIndex).name.Equals(sceneName)) return true;
            }
            
            return false;
        }
    }
}