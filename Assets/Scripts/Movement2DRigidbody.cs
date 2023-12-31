using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2DRigidbody : MonoBehaviour
{

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private int maxJumps = 1;

    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Caching
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
     
        if(rigidbody2D.velocity.x < 0)
        {
            //spriteRenderer.flipX = true;
            animator.Play("WALK");
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rigidbody2D.velocity.x > 0)
        {
            //spriteRenderer.flipX = false;
            animator.Play("WALK");
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.Play("IDLE");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        float yNormal = collision.contacts[0].normal.y;

        if (yNormal > 0.8f)
        {
            jumpCount = 0;
        }
    }


    public void Jump()
    {
        if (jumpCount < maxJumps)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            jumpCount++;
        }
    }
    
    public void Move(float xDirection)
    {
        rigidbody2D.velocity = new Vector3(horizontalSpeed * xDirection, rigidbody2D.velocity.y, 0);
    }
}
