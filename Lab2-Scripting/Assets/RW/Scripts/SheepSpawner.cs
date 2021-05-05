using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;

    private int numSheepsSpawned;
    private float sheepVelIncrement;

    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;

    private List<GameObject> sheepList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        numSheepsSpawned = 0;
        sheepVelIncrement = 0.0f;
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
        sheep.GetComponent<Sheep>().IncrementVel(sheepVelIncrement);

        numSheepsSpawned += 1;
        if(numSheepsSpawned % 2 == 0)
        {
            sheepVelIncrement += 1.0f;
        }
    }

    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList) 
        {
            Destroy(sheep);
        }

        sheepList.Clear();
    }
}
