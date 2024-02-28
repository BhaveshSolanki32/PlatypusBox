using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovmentHandler : MonoBehaviour //handels player and camera rotation with mouse
{
    [SerializeField] float _horizontalSensitivity=0.5f;
    [SerializeField] float _verticalSensitivity = 0.5f;

    Transform _cameraTransform;
    Vector2 _turn;//stores the added up rotation due to mouse movement

    private void Awake()
    {
        _cameraTransform = Camera.main.transform; //gets transform of camera
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor to the center if the screen
    }

    void FixedUpdate()
    {
        //adding rotaion due to mouse movement
        _turn.x += Input.GetAxis("Mouse X") * _horizontalSensitivity;
        _turn.y -= Input.GetAxis("Mouse Y") * _horizontalSensitivity;
        //clamps the x axis rotation of camera to a certain threshold limiting camera rotaion
        _turn.y = Mathf.Clamp(_turn.y, -31.698f, 43.007f); 

        var newRotation = Quaternion.Euler(_turn.y, _turn.x, 0); //finding rotation 

        _cameraTransform.transform.localRotation = newRotation; //assigning rotaion to camera

        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, _turn.x, transform.localEulerAngles.z); //assigning rotaion along y axis to player

    }
}
