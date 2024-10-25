using UnityEngine;
using System.Collections.Generic;

public class RandomCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    private float planeSize = 5f; // po³owa boku, aby Cube
    private List<Vector3> blockedPositions = new List<Vector3>();

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition;

            do
            {
                float x = Random.Range(-planeSize, planeSize);
                float z = Random.Range(-planeSize, planeSize);
                randomPosition = new Vector3(x, 0.5f, z);
            }
            while (IsPositionBlocked(randomPosition));

            blockedPositions.Add(randomPosition);

            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    bool IsPositionBlocked(Vector3 position)
    {
        foreach (Vector3 occupiedPosition in blockedPositions)
        {
            if (Vector3.Distance(occupiedPosition, position) < 1f)
            {
                return true;
            }
        }
        return false;
    }
}
