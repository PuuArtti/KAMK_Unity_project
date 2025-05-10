using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class PlayerController : MonoBehaviour
{
    public float HorizontalMove = 0f;
    public float speed = 8f;
    Vector2 move;
    Rigidbody2D rb;
    public float jumping = 100f;
    public CharacterController2D controller;
   public bool jump = false;
    bool isDead = false;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumping");
            jump = true;
            controller.Jump();
        }
    }

    void FixedUpdate()
    {
        //Move Character
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
    }

    private void Flip() 
    {
       
    
    }

    public void Die()
    {
        isDead = true;
    }
}
