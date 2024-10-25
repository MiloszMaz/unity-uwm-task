using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab03_Zadanie3 : MonoBehaviour
{
    public float speed = 1.0f;

    public float distance = 10;

    private float firstStartPositionX;

    private Vector3 startPosition;
    private bool isReturned = false;

    private int rotatedCount = 0;

    private Vector3[] directions;

    private int currentEdge = 0;


    void Start()
    {
        startPosition = transform.position;

        firstStartPositionX = startPosition.x;

        directions = new Vector3[] {
            Vector3.right,
            Vector3.forward,
            Vector3.left,
            Vector3.back
        };
    }

    void Update()
    {
        float toPositionX = startPosition.x + distance;

        float currentPositionX = transform.position.x;

        

        if (!(rotatedCount >= 4 && currentPositionX <= firstStartPositionX))
        {
            transform.Translate(directions[currentEdge] * speed * Time.deltaTime);

            if (currentPositionX >= toPositionX)
            {
                makeRotate();
            }

            Debug.Log("Blokada 1: " + rotatedCount + " " + currentPositionX + " " + firstStartPositionX);
        }

        Debug.Log("Blokada 2: " + rotatedCount + " " + currentPositionX + " " + firstStartPositionX);

    }

    void makeRotate()
    {
        transform.Rotate(0, 90, 0);

        startPosition = transform.position;

        currentEdge = (currentEdge + 1) % 4;

        rotatedCount++;

        Debug.Log("rotatedCount: " + rotatedCount);
    }
}
