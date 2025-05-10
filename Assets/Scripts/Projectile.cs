using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public Rigidbody2D rb;
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
        
        if (rb != null) 
        {
            rb.linearVelocity = direction * speed;
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Flip horizontally (negative X)
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Default scale (positive X)
            }
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
            if (Input.GetButtonDown("Fire2"))
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
        if (collision.CompareTag("Shield"))
            Bounce();
    }

    public void Bounce()
    {
        if (rb != null)
        {
            rb.linearVelocity = -rb.linearVelocity; 
        }
        else
        {
            Debug.LogError("Rigidbody2D is not initialized!");
        }

        transform.localScale = new Vector2(-1,1); 
    }
}