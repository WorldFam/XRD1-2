using UnityEngine;
using UnityEngine.XR.ARFoundation;
 
 
public class FaceAngleRelativeToCamera : MonoBehaviour {
    [SerializeField] GameObject face = null;
    [SerializeField] ARSessionOrigin origin = null;
 
    [Header("Debug")]
    [SerializeField] Vector3 eulerAnglesRelativeToCamera;
 
 
 
    void Update() {
        var rotationRelativeToCamera = Quaternion.Inverse(origin.camera.transform.rotation) * face.transform.rotation; // this quaternion represents a face rotation relative to camera
        eulerAnglesRelativeToCamera = rotationRelativeToCamera.eulerAngles; // using euler angles is almost always a bad idea
        Debug.Log($"eulerAnglesRelativeToCamera: {eulerAnglesRelativeToCamera}");
        Debug.Log($"face.transform.rotation: {face.transform.rotation}");
        Debug.Log($"Quaternion.Inverse(origin.camera.transform.rotation): {Quaternion.Inverse(origin.camera.transform.rotation)}");


    }
}