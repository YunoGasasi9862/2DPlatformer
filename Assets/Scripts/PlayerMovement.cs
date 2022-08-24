using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float CharacterSpeed = 10f;
    [SerializeField] float jumpspeed = 10f;
    bool isontheGround = true;
    private Rigidbody2D rb;

    private Animator anim;

    private SpriteRenderer sr;

    float Horizontal = 0f;

    private BoxCollider2D collider;
    [SerializeField] LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling};
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {


        Horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Horizontal * CharacterSpeed, rb.velocity.y);
        if( Input.GetButtonDown("Jump") && isontheGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            rb.gravityScale = 2.0f;
            isontheGround = false;

        }

        ImplementAnimation();
        ChangeDirection();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if(collision.collider.tag=="Ground")
        {
            rb.gravityScale = 1;
            isontheGround = true;
        }
    }

    private void ImplementAnimation()
    {
        MovementState state;
        if(Horizontal > 0f)
        {
            state = MovementState.running;
        }else if(Horizontal <0f)
        {
            state = MovementState.running;

        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }else if(rb.velocity.y <-0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private void ChangeDirection()
    {
       if(Horizontal <0f)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    private bool isGrounder()
    {
        Physics2D.BoxCast(collider.bounds.center, collider.bounds.size,
            0f, Vector2.down, .1f, )
    }
}
