using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;

    // public Animator TransitionAnimation;
    // WaitForSeconds delay = new WaitForSeconds(1);
    public static Vector2 LastCheckPoint = new Vector2(-3,0);
    public int JumpCount;
    int maxJumpCount;
    bool grounded;
    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sr;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPoint;
        maxJumpCount = JumpCount;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }
    private void FixedUpdate()
    {
        //TransformMovement();
        // UpdateAnimationUpdate();
        RigidbodyMovement();
        ani.SetFloat("MovementX", Mathf.Abs(rb.velocity.x));
        ani.SetFloat("MovementY", Mathf.Abs(rb.velocity.y));
        ani.SetBool("grounded", grounded);
    }
    private void Update()
    {
      
         if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("Jump",true);
            Jump();
        }
         if (Input.GetKeyUp(KeyCode.Space))
        {
            ani.SetBool("Jump",false);
        }
     
    }

    public void TransformMovement()
    {
        float movementDir = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector2(transform.position.x + (MovementSpeed * movementDir * Time.deltaTime), transform.position.y);

    }
    public void RigidbodyMovement()
    {
        float movementDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementDir * MovementSpeed * Time.deltaTime, rb.velocity.y);

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }
    void Jump()
    {
        if (JumpCount > 0)
        {
            JumpCount--; // JumpCount = -1 / JumpCount -= 1;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            // ani.Play("JumJum");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            JumpCount = maxJumpCount;
            grounded = true;
            
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        // setting the grounded boolean to false when leaving the collision area of  the "Ground"
        if (collision.gameObject.tag.Equals("Ground"))
        {
            
            grounded = false;
        }
        
       
    }

    public GameObject GameOverCanva;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Coins"))
        {
            
            Destroy(other.gameObject);

        }
        if(other.gameObject.CompareTag("bahay ni batman"))
        {
            GameOverCanva.SetActive(true);
        }
    }
    
    
     


    // private void UpdateAnimationUpdate()
    // {
    //     MovementState state;

    //     if (dX > 0f)
    //     {
    //         state = MovementState.running;
    //         sprite.flipX = false;
    //     }
    //     else if (dX < 0f)
    //     {
    //         state = MovementState.running;
    //         sprite.flipX = true;
    //     }
    //     else
    //     {
    //         state = MovementState.idle;
    //     }

    //     if (rb.velocity.y > .1f)
    //     {
    //         state = MovementState.jumping;
    //     }
    //     else if (rb.velocity.y < -.1f)
    //     {
    //         state = MovementState.falling;
    //     }

    //     an.SetInteger("state", (int)state);
    // }

    // private bool IsGrounded()
    // {
    //     return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    // }
}
