using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        float hInputValue = Input.GetAxisRaw("Horizontal"); // Values {-1, 0, 1}

        
        Vector3 translateValue = transform.right * hInputValue * movementSpeed * Time.deltaTime;
        Vector3 targetPos = transform.position + translateValue;

        if (PositionInsideBoundaries(targetPos))
        {
            transform.Translate(translateValue);
        }
    }

    private bool PositionInsideBoundaries(Vector3 position)
    {
        return position.x > -horizontalBoundary && position.x < horizontalBoundary;

    }
}
