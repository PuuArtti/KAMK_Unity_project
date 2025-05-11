using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_melee : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0F;
    Rigidbody2D rb;
    public bool isAttackActive = false;
    public float attackActiveTimer = 0.3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Melee();
                
                nextAttackTime = Time.time + 1f / attackRate;
                
                

            }
            
        }       
    }


    public void Melee() 
    {
        //Play attack Anim
        animator.SetTrigger("Attack");
        isAttackActive = true;
        attackActiveTimer -= Time.time;
        if (attackActiveTimer <= 0f)
        {
            isAttackActive =false;
        }

        //Detect enemies in range of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        //Damage them
        foreach(Collider2D enemy in hitEnemies) 
        {
            Vector2 sourceposition = transform.position; //Players position
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage();
            enemy.GetComponent<KnockBAck>().ApplyKnockback(sourceposition);
            



        }

           
    
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Reset()
    {
        
    }

}
