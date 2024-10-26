using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchForceMultiplier = 3f;
    private PlayerMovement playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed� na p�yt� naciskow�.");

            playerController = other.GetComponent<PlayerMovement>();

            if (playerController != null)
            {
                Debug.Log("Wyrzu� gracza.");
                playerController.LaunchPlayer(launchForceMultiplier);
            }
        }
    }
}
