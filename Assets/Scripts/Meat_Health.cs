using UnityEngine;

public class Meat_Health : MonoBehaviour
{
    public GameObject Player_Ref;
    public AudioClip Unga_sound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
        audioSource.clip = Unga_sound;
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
            audioSource.Play();

            GetComponent<Renderer>().enabled = false;

            Destroy(gameObject, Unga_sound.length);
        }
    }
}
