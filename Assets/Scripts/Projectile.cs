using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the projectile!");
        }

        // Destroy the projectile after its lifetime
        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector2 direction)
    {
        if (rb != null) // Ensure Rigidbody2D is not null
        {
            rb.linearVelocity = direction * speed; // Use linearVelocity instead of velocity
        }
        else
        {
            Debug.LogError("Rigidbody2D is not assigned or missing!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetButton("Fire2"))
            {
                Bounce();
            }
            else
            {
                Vector2 sourcePosition = transform.position;

                KnockBAck knockbackComponent = collision.GetComponent<KnockBAck>();
                if (knockbackComponent != null)
                {
                    knockbackComponent.ApplyKnockback(sourcePosition);
                }
                else
                {
                    Debug.LogError("KnockBAck component is missing on the Player!");
                }

                Health healthComponent = FindAnyObjectByType<Health>();
                if (healthComponent != null)
                {
                    healthComponent.LoseLife();
                }
                else
                {
                    Debug.LogError("Health component could not be found!");
                }

                Destroy(gameObject);
            }
        }
    }

    public void Bounce()
    {
        if (rb != null)
        {
            rb.linearVelocity = -rb.linearVelocity; // Reverse the velocity using linearVelocity
        }
        else
        {
            Debug.LogError("Rigidbody2D is not initialized!");
        }
    }
}