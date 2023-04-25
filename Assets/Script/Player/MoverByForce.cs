using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class MoverByForce : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    Vector2 _input;
    [SerializeField] Transform _target;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void MoveByVelocity()
    {
        Vector2 dir = (_target.position - transform.position);
        float distance = dir.magnitude;

        dir = dir.normalized;
        dir *= distance;

        //_rigidbody.AddForce(dir * _force, ForceMode2D.Force);

        _rigidbody.velocity = dir * _speed;
    }
}
