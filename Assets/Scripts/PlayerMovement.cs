using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float CharacterSpeed = 10f;
    [SerializeField] float jumpspeed = 10f;
    private Rigidbody2D rb;

    private Animator anim;

    private SpriteRenderer sr;

    float Horizontal = 0f;

    private BoxCollider2D col;

    [SerializeField] LayerMask jumpableGround;
    [SerializeField] LayerMask PlatformJump;

    private enum MovementState {idle, running, jumping, falling};

    [SerializeField] private AudioSource JumpSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    void Update()
    {


        Horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Horizontal * CharacterSpeed, rb.velocity.y);


        if( Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            JumpSound.Play();
        }

        if(Input.GetButtonDown("Jump") && isOnthePlatform())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            JumpSound.Play();
        }



        ImplementAnimation();
        ChangeDirection();


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

        
        if(rb.velocity.y >=.1f)
        {
            state = MovementState.jumping;
        }else if(rb.velocity.y <=-.1f)
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

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .3f, jumpableGround);
    }

    private bool isOnthePlatform()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .3f, PlatformJump);

    }
}
