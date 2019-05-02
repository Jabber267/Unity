﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Private Vars
    Vector3 initialPos;
    int direction = 1;
    // Public Vars
    public float speed = 3;
    public float rangeY = 2;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float factor = direction == -1 ? 1.2f : 1;

        float movementY = factor * speed * Time.deltaTime * direction;
        float newY = transform.position.y + movementY;
        if (Mathf.Abs(newY - initialPos.y) > rangeY)
        {
            direction *= -1;
        }
        else
        {
            transform.position += new Vector3(0, movementY, 0);
        }
    }
}
