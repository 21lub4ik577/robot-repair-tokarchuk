
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthAmount = 1;

    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            controller.ChangeHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
