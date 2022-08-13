using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(Horizontal, Vertical, 0);
    }
}
