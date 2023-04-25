using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class InputMover : MonoBehaviour
{
    [SerializeField]
    ControlType _controlType;

    Rigidbody2D _rigidbody;

    Vector2 _input;

    [SerializeField] private float speed = 1;

    [SerializeField] private float force;

    [SerializeField] private float maxVelocity;

    [SerializeField]
    [Range(0,1)] private float _smoothing = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_controlType == ControlType.Velocity)
        {
            MoveByVelocity();
        }
        if (_controlType == ControlType.Force)
        {
            MoveByForce();
        }
    }

    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void MoveByForce()
    {
        var targetVelocity = _input * speed;
        var actualVelocity = Vector2.Lerp(_rigidbody.velocity, targetVelocity, _smoothing);

        float mag = actualVelocity.magnitude;

        actualVelocity = actualVelocity.normalized;
        actualVelocity *= Mathf.Min(mag, maxVelocity);

        _rigidbody.velocity = actualVelocity;
    }

    private void MoveByVelocity()
    {
        
        _rigidbody.AddForce(_input * force, ForceMode2D.Force);
    }

    /*private void GetInputs()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
    }*/

}

enum ControlType
{
    Force,
    Velocity
}
