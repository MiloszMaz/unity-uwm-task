using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchForceMultiplier = 3f;
    private PlayerMovement playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed³ na p³ytê naciskow¹.");

            playerController = other.GetComponent<PlayerMovement>();

            if (playerController != null)
            {
                Debug.Log("Wyrzuæ gracza.");
                playerController.LaunchPlayer(launchForceMultiplier);
            }
        }
    }
}
