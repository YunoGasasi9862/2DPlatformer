using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTothePlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            transform.parent = collision.transform;//this sets the transform or make the collisions child
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
    
       
    
}
