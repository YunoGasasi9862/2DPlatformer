using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int KiwiCounter = 0;
    [SerializeField] TextMeshProUGUI KiwiText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Kiwi"))
        {
            KiwiCounter++;
            KiwiText.text = "Kiwis: " + KiwiCounter;
            Destroy(collision.gameObject);
        }
    }
}
