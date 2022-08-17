using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float CharacterSpeed = 10f;
    public float jumpspeed = 10f;
    bool isontheGround = true;
    private Rigidbody2D rb;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {


        float Horizontal = Input.GetAxisRaw("Horizontal");
        // rb.velocity= new Vector2( Horizontal * CharacterSpeed, rb.velocity.y); //it's better to use velocity
        rb.velocity = new Vector2(Horizontal * CharacterSpeed, rb.velocity.y);

        if(rb.velocity.x != 0)
        {
            anim.SetBool("RUNNING", true);
        }
        else
        {
            anim.SetBool("RUNNING", false);
        }

        if (Input.GetButtonDown("Jump") && isontheGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpspeed); //Since we are not even using Rb.addforce, or ForceMode2D.Impulse, the physics will automatically calculate the gravity etc
            rb.gravityScale = 2.0f;
            isontheGround = false;
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if(collision.collider.tag=="Ground")
        {
            rb.gravityScale = 1f;
            isontheGround = true;
        }
    }
}
