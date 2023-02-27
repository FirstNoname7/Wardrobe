using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    float horizontalInput;
    public float HorizontalInput
    {
        get => horizontalInput;
        set
        {
            horizontalInput = value;
            if (horizontalInput != 0)
            {
                Move();
            }
        }
    }

    private void Move()
    {
        transform.Rotate(Vector3.down * horizontalInput * rotationSpeed * Time.deltaTime);
    }


    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
    }
}
