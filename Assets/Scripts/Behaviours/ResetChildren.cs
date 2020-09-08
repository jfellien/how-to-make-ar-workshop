using System;
using easyar;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(ImageTargetController))]
    public class ResetChildren : MonoBehaviour
    {
        private ImageTargetController imageTargetController;

        private void Awake()
        {
            imageTargetController = GetComponent<ImageTargetController>();
            imageTargetController.TargetFound += ResetChildObjects;
        }

        private void ResetChildObjects()
        {
            foreach (Transform transform in gameObject.transform)
            {
                transform.position = Vector3.zero;
            }
        }
    }
}