using UnityEngine;

public class StoneDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kolizja");
        if (collision.gameObject.CompareTag("Stone"))
        {
            Debug.Log("[OnCollisionEnter] Uwaga kamieñ!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            Debug.Log("[OnTriggerEnter] Uwaga kamieñ!");
        }
    }
}
