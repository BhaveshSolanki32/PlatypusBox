using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour //follows player with an offset
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _yOffset = 0.74f;
    private void Update()
    {
        transform.position = new(_playerTransform.position.x, _playerTransform.position.y+_yOffset, _playerTransform.position.z);
    }
}
