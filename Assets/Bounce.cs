using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float _bounceForce;
    [SerializeField] float _maxVelocity;
    Rigidbody2D _rb;

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody2D>(out _rb))
            Debug.LogError("RigidBody not found", gameObject);
    }
    void LateUpdate()
    {
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var surfaceNormal = collision.GetContact(0).normal;
        _rb.AddForce(_bounceForce * surfaceNormal);
    }


}
