using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;

    public GameObject hayBalePrefab; 
    public Transform haySpawnpoint;
    public float shootInterval; 
    private float shootTimer;

    public Transform modelParent; 

    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); 

        switch (GameSettings.hayMachineColor) 
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
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

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime; 

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
        {
            shootTimer = shootInterval; 
            ShootHay();
        }
    }

    private void ShootHay()
    {
        SoundManager.Instance.PlayShootClip();
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }
}
