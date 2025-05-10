using UnityEngine;

public class KnockBAck : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.2f;
    private bool isKnockedBack = false;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 sourcePosition) 
    {
        if (isKnockedBack) 
            return;
        isKnockedBack=true;

        //Calculate the knockback direction
        Vector2 knockbackDirection = (rb.position - sourcePosition).normalized;

        //Apply force
        rb.AddForce(knockbackDirection *  knockbackForce, ForceMode2D.Impulse);

        //End knockback after a duration
        Invoke(nameof(EndKnockback), knockbackDuration);
    }


    private void EndKnockback() 
    {
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false ;
    }
}
