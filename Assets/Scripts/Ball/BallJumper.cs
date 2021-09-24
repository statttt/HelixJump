using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private bool isCollision = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
            {
            if(!isCollision)
            {
                isCollision = true;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
            }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            isCollision = false;
        }
    }



}
