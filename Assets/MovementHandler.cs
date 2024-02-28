using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour //handels player movement 
{
    [SerializeField] float _speed; //normal movemnt speed of player
    [SerializeField] float _sprintSpeed; //sprint speed of player
    [SerializeField] float _jumpForce; //jump force
    Rigidbody _rb; //rigidbody component of the player
    bool _isInAir = false; //check if player is in air or not

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody>(out _rb))
            Debug.LogError("RigidBody not found", gameObject);
    }

    private void Update()
    {
        var speed = _speed;

        if (Input.GetKey(KeyCode.LeftShift))//hold shift to sprint
        {
            speed = _sprintSpeed;
        }
        var forwardSpeed = speed * transform.forward*Time.deltaTime;
        var sideSpeed = speed * transform.right * Time.deltaTime;


        if (Input.GetKey(KeyCode.W)) //forward movement
        {
            transform.position = new Vector3(transform.position.x + forwardSpeed.x, transform.position.y, transform.position.z + forwardSpeed.z);
        }
        else if (Input.GetKey(KeyCode.S)) // backward movement
        {
            transform.position = new(transform.position.x - forwardSpeed.x, transform.position.y, transform.position.z - forwardSpeed.z);
        }

        if (Input.GetKey(KeyCode.A))//left movement
        {
            transform.position = new(transform.position.x - sideSpeed.x , transform.position.y, transform.position.z - sideSpeed.z);
        }
        else if (Input.GetKey(KeyCode.D))//right movement
        {
            transform.position = new(transform.position.x + sideSpeed.x, transform.position.y, transform.position.z + sideSpeed.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isInAir) //check if space is pressed and player is not in air to jump
        {
            _rb.AddForce(new(0, _jumpForce*Time.deltaTime, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")//checks if player is on ground
        {
            _isInAir = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")//checks if player is in air
        {
            _isInAir = true;
        }
    }
}
