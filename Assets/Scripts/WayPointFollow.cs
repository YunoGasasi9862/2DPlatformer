using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;

     private int currentWayPointIndex = 0;

    [SerializeField] private float speed = 2f;



   
   
    void Update()
    {

        if(Vector2.Distance(transform.position, waypoints[currentWayPointIndex].transform.position)<=0.1f)
        {
            currentWayPointIndex++;

            if(currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
