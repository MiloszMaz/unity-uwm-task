using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab03 : MonoBehaviour
{
    public float speed = 1.0f;

    public float distance = 10;

    private Vector3 startPosition;
    private bool isMovingBack = false;
    private bool isReturned = false;


    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(distance * speed, 0, 0);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float toPositionX = startPosition.x + distance;

        float currentPositionX = transform.position.x;

        if(isReturned)
        {
            return;
        }

        if (isMovingBack)
        {
            if (currentPositionX <= startPosition.x)
            {
                isReturned = true;
            }

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } 
        else
        {
            if (currentPositionX >= toPositionX)
            {
                isMovingBack = true;
            }

            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
