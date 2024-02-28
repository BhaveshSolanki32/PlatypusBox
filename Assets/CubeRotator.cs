using System.Collections;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 45f; // Degrees per second

    void Update()
    {
        // Calculate incremental rotation
        float rotationDelta = _rotationSpeed * Time.deltaTime;

        // finding rotation based on degree of rotation
        Quaternion rotation = Quaternion.AngleAxis(_rotationSpeed, Vector3.up);

        // applying the rotation to the object's transform
        transform.rotation = rotation * transform.rotation;
    }
}