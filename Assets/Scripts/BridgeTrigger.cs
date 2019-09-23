using UnityEngine;
using UnityEngine.Tilemaps;

public class BridgeTrigger : MonoBehaviour
{
    public Collider2D objectCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectCollider != null && other.CompareTag("Player"))
        {
            objectCollider.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (objectCollider != null && other.CompareTag("Player"))
        {
            objectCollider.enabled = true;
        }
    }
}
