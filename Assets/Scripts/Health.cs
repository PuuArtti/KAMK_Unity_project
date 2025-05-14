using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Image[] lives;
    public int livesRemaining = 3;
    public PlayerController controller;
    

    
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife() 
    {
        //Decrease the value of livesRemaining
        livesRemaining--;

        

        //Hide one heart image
        lives[livesRemaining].enabled = false;

        //If out of lives -> game over
        if (livesRemaining == 0) 
        {

            FindFirstObjectByType<GameManager>().Restart();
            
        
        
        }
    
    
    }

    public void AddLive() 
    {
        if (livesRemaining < 3)
        {
            
            lives[livesRemaining].enabled = true;
            livesRemaining++;
        }
        else
        {
            return;
        }

    }

   
}
