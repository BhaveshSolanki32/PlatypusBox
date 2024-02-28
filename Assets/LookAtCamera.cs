using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Transform _cameraTransform; // Reference to the camera's transform component

    private void Awake()
    {
        _cameraTransform = Camera.main.transform; //gets transform of camera
    }

    void Update()
    {
        if (_cameraTransform != null)
        {
            // Calculate the direction from the object to the camera
            var lookDirection = _cameraTransform.position - transform.position;

            // Use LookAt to rotate the object towards the camera
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        else
        {
            Debug.LogError("No camera not found", gameObject);
        }
    }
}