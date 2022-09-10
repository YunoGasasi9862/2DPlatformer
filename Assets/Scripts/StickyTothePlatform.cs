using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTothePlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
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
