using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RandomCubesGenerator : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    private int objectCounter = 0;
    public GameObject block;
    public int numberOfObjects = 10;
    public Material[] materials;

    void Start()
    {
        Bounds platformBounds = GetComponent<Renderer>().bounds;

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition;
            do
            {
                float x = Random.Range(platformBounds.min.x, platformBounds.max.x);
                float z = Random.Range(platformBounds.min.z, platformBounds.max.z);
                randomPosition = new Vector3(x, platformBounds.center.y + 0.5f, z);
            } while (positions.Any(pos => Vector3.Distance(pos, randomPosition) < 1f));

            positions.Add(randomPosition);
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            yield return new WaitForSeconds(delay);
        }

        StopCoroutine(GenerujObiekt());
    }
}
