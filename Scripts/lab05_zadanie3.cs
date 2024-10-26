using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointToPoint : MonoBehaviour
{
    public float speed = 2f;
    public List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;

        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i] += initialPosition;
        }
    }

    void Update()
    {
        if (waypoints.Count == 0) return; // nie ma punktów = nie rusza sie

        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            UpdateWaypointIndex();
        }
    }

    void UpdateWaypointIndex()
    {
        if (movingForward && currentWaypointIndex == waypoints.Count - 1)
        {
            movingForward = false;
        }

        else if (!movingForward && currentWaypointIndex == 0)
        {
            movingForward = true;
        }

        currentWaypointIndex = movingForward ? currentWaypointIndex + 1 : currentWaypointIndex - 1;
    }
}
