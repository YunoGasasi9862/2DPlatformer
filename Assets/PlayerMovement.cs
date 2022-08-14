using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float CharacterSpeed = 50f;
    public float jumpspeed = 10f;
    bool isontheGround = true;
    [SerializeField] Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * CharacterSpeed * Time.deltaTime;

        transform.Translate(Horizontal, 0,0);

        if (Input.GetButtonDown("Jump") && isontheGround)
        {
            rb.AddForce(Vector3.up * jumpspeed, ForceMode2D.Impulse);
            rb.gravityScale = 1.5f;
            isontheGround = false;

            //another method is this:
            //rb.velocity=new vector3(0,speed,0);
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if(collision.collider.tag=="Ground")
        {
            rb.gravityScale = 1;
            isontheGround = true;
        }
    }
}
