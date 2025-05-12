using UnityEngine;

public class Meat_Health : MonoBehaviour
{
    public GameObject Player_Ref;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Health>().AddLive();
            Destroy(gameObject);
        }
    }
}
