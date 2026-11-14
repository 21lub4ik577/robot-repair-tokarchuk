
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public AudioClip launchSound;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);

        if (launchSound != null)
        {
            AudioSource.PlayClipAtPoint(launchSound, transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy =
            other.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.Fix();
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
