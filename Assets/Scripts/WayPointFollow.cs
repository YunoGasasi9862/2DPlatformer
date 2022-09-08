using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;

    //  private int currentWayPointIndex = 0;

    //  [SerializeField] private float speed = 2f;

    [SerializeField] Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {

        //THIS IS MY APPROACH FOR USING SIN WAVE FOR MOVING THE PLATFORM!!!!!

        float amplitude = Mathf.Abs(waypoints[0].transform.position.x - waypoints[1].transform.position.x);
        transform.position = pos +  transform.right * amplitude/2 * Mathf.Cos(Time.time);
      

    }
}
