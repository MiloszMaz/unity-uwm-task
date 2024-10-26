using System.Collections;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float platformSpeed = 2f;
    public Vector3 destinationOffset;
    private bool isMoving = false;
    private bool movingToDestination = true;
    private Vector3 startPosition;
    private Vector3 destinationPosition;
    private Transform oldParent;

    void Start()
    {
        startPosition = transform.position;
        destinationPosition = startPosition + destinationOffset;
    }

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        Vector3 targetPosition = movingToDestination ? destinationPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, platformSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingToDestination = !movingToDestination;
            isMoving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ruch 1");

        if (other.gameObject.CompareTag("Player"))
        {
            oldParent = other.gameObject.transform.parent;

            other.gameObject.transform.parent = transform;

            Debug.Log("Player wszed³ na windê.");
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("[OnCollisionEnter] Ruch 1");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("[OnCollisionEnter] Player wszed³ na platformê.");
            oldParent = collision.transform.parent;
            collision.transform.parent = this.transform;
            isMoving = true;
        }
    }
}
