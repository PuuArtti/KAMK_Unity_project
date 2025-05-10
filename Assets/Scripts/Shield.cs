using UnityEngine;

public class Shield : MonoBehaviour
{
    public Player_melee player_Melee;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_Melee != null && player_Melee.isAttacking)
        {
            Active(); // Activate the shield when the player is attacking
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false; // Deactivate the shield otherwise
        }

    }
    void Active() 
    {
        GetComponent<BoxCollider2D> ().enabled = true;
    }
}
