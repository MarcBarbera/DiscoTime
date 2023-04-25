using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float Speed = 1;
    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        transform.Rotate(new Vector3(0, 0, Speed) * Time.deltaTime);
    }
}
