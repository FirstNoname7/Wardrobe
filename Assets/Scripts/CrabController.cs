using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float HorizontalInput
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
    float VerticalInput
    {
        get => verticalInput;
        set
        {
            verticalInput = value;
            if (verticalInput != 0)
            {
                Move();
            }
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.right * 2 * horizontalInput);
        transform.Translate(Vector3.up * 2 * verticalInput);
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }
}
