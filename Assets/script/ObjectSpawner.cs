using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject redCubePrefab;
    public GameObject blueCubePrefab;
    public int redCubeCount = 20;
    public int blueCubeCount = 10;
    public float groundSize = 75f;
    public float minDistance = 5f;

    private List<Vector3> spawnedPositions = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects(redCubePrefab, redCubeCount);
        SpawnObjects(blueCubePrefab, blueCubeCount);
    }

    void SpawnObjects(GameObject prefab, int count)
    {
        int spawned = 0;

        while (spawned < count)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-groundSize, groundSize),
                0.5f,
                Random.Range(-groundSize, groundSize)
            );

            if (IsPositionValid(randomPosition))
            {
                Instantiate(prefab, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
                spawnedPositions.Add(randomPosition);
                spawned++;
            }
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 pos in spawnedPositions)
        {
            if (Vector3.Distance(pos, position) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}
