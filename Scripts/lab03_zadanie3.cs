using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab03_Zadanie3 : MonoBehaviour
{
    public float speed = 1.0f;

    public float distance = 10;

    private Vector3 startPosition;

    private Vector3[] directions;

    private int currentEdge = 0;

    private bool isTurning = false;


    void Start()
    {
        startPosition = transform.position;

        directions = new Vector3[] {
            Vector3.right,
            Vector3.forward,
            Vector3.left,
            Vector3.back
        };
    }

    void Update()
    {
        if (!isTurning)
        {
            move();
        }
        else
        {
            rotate();
        }
    }

    void move()
    {
        transform.Translate(directions[currentEdge] * speed * Time.deltaTime);
        float movedDistance = Vector3.Distance(startPosition, transform.position);

        if (movedDistance >= distance)
        {
            isTurning = true;
            startPosition = transform.position;
        }
    }

    void rotate()
    {
        transform.Rotate(Vector3.up, 90 * Time.deltaTime);

        isTurning = false;
        currentEdge = (currentEdge + 1) % 4;

        Debug.LogWarning("Obrot!");
    }
}
