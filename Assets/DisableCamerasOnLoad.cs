using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCamerasOnLoad : MonoBehaviour {
    List<Camera> sceneCameras = new List<Camera>();

    void Start() {
        sceneCameras.Clear();
        foreach (var root in gameObject.scene.GetRootGameObjects())
        {
            foreach (var camera in root.GetComponentsInChildren<Camera>())
            {
                camera.enabled = false;
                sceneCameras.Add(camera);
            }
        }
    }
}
