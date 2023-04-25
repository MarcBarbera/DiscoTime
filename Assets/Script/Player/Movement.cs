using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float maxY = 10;

    [SerializeField] float minY = -8f;

    [SerializeField] float minX = -18f;

    [SerializeField] float maxX = 18f;

    [SerializeField] float speed = 1;

    Vector2 direction = new Vector2(0,1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpAndDown();
    }

    private void MoveUpAndDown()
    {
        if(transform.position.y >= maxY)
        {
            direction = new Vector2(0, -1);
        }
        if(transform.position.y <= minY)
        {
            direction = new Vector2(0, 1);
        }

        transform.Translate(direction * speed * Time.deltaTime);
        
    }
}
