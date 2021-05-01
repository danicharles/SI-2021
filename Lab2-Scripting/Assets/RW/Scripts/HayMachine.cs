using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
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
        transform.Translate(transform.right * hInputValue * movementSpeed * Time.deltaTime);
    }
}
