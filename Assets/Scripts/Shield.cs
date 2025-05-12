using UnityEngine;

public class Shield : MonoBehaviour
{
    public Player_melee player_Melee;
    public bool ShieldActive = true;
    public BoxCollider2D boxCollider;
    public Projectile projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }
    void Active() 
    {
       ShieldActive = GetComponent<BoxCollider2D> ().enabled = true;
    }

   

}
