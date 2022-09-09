using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;

     private int currentWayPointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
       // pos = transform.position;

    }
    void Update()
    {

        //THIS IS MY APPROACH FOR USING SIN WAVE FOR MOVING THE PLATFORM!!!!!
        // amplitude = Mathf.Abs(waypoints[0].transform.position.x - waypoints[1].transform.position.x);

        // transform.position = pos + transform.right * (amplitude/2 + difference)* (Mathf.Sin(Time.time));  //pos makes sure that it remains at its exact position, and oscillates from there!!!

        if (  Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {

            currentWayPointIndex++;

            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }

        }
     

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);


    }
}
