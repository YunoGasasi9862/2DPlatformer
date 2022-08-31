using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int KiwiCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Kiwi"))
        {
            KiwiCounter++;
            Destroy(collision.gameObject);
        }
    }
}
