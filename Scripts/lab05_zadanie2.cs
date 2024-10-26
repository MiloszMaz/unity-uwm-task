using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float openDistance = 10f;
    public float speed = 2f;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = transform.position;

        openPosition = closedPosition + new Vector3(openDistance, 0, 0);
    }

    void Update()
    {
        if (isOpening)
        {
            // otwieraj
            transform.position = Vector3.MoveTowards(transform.position, openPosition, speed * Time.deltaTime);

            // otwarte - stop
            if (transform.position == openPosition)
            {
                isOpening = false;
            }
        }
        else
        {
            // zamknij
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            Debug.Log("Gracz w pobli¿u - otwieranie drzwi.");
            isOpening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz siê oddali³ - zamykanie drzwi.");
            isOpening = false;
        }
    }
}