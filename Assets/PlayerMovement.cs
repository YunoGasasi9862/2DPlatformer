using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float CharacterSpeed = 10f;
    public float jumpspeed = 10f;
    bool isontheGround = true;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity= new Vector2( Horizontal * CharacterSpeed, rb.velocity.y); //it's better to use velocity

        if (Input.GetButtonDown("Jump") && isontheGround)
        {

            rb.velocity= new Vector2(rb.velocity.x, jumpspeed);
            rb.gravityScale = 2f;
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
