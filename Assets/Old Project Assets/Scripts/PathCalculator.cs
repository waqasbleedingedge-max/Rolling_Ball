using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NA;

public class PathCalculator : SimpleSingleton<PathCalculator>
{
    public GameObject Main;

    public Slider fill;
    //public Transform arrow;
   // public Transform[] waypoints;
    private int currentWaypoint;
    private int  totalDistance;

  //  private int prevIndex;
   // private float prevDistance;
    private bool cal = false;
    float waypointsToWaypointDistance = 0.0f;
    float playertoWaypointDistance = 0.0f;

    float calculatedDistance = 0.0f;

    private void OnEnable()
    {
        Invoke(nameof(_wait), 0.1f);
    }
    void _wait()
    {
        Main = transform.parent.gameObject;
    }
    private void Start()
    {
        Invoke("Init", 3f);
        //Init();

    }

    private void Init()
    {
        if (Activity.Instance)
        {
            cal = true;
            totalDistance = (Activity.Instance.wayPoints.Length + 1) * 100;
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Waypoint"))
        {
            currentWaypoint = other.gameObject.GetComponent<Index>().index;
        }
    }

    private void LateUpdate()
    {
        if (cal)
        {
            CalculateDistance();
         //   if(currentWaypoint< Activity.Instance.wayPoints.Length)
            //    arrow.LookAt(Activity.Instance.wayPoints[currentWaypoint + 1].position);
        }
            
    }

    public void CalculateDistance()
    {
        if(currentWaypoint< Activity.Instance.wayPoints.Length-1)
        {
            waypointsToWaypointDistance = Vector3.Distance(Activity.Instance.wayPoints[currentWaypoint].position, Activity.Instance.wayPoints[currentWaypoint + 1].position);
            playertoWaypointDistance = Vector3.Distance(transform.position, Activity.Instance.wayPoints[currentWaypoint + 1].position);

            calculatedDistance = (playertoWaypointDistance / waypointsToWaypointDistance) * 100;

          //  Debug.Log("Total Distance " + totalDistance);
        //    Debug.Log("Calculated total Distance " + calculatedDistance);
          //  Debug.Log("Distance = " + (calculatedDistance + (((waypoints.Length-1) - (currentWaypoint+1)) * 100)));
          //  Debug.Log("Slider Value = " + (1f - (((calculatedDistance + ((waypoints.Length - currentWaypoint) * 100)) / totalDistance))));

            fill.value = 1f - (((calculatedDistance + ((Activity.Instance.wayPoints.Length - currentWaypoint) * 100)) / totalDistance));
        }
        else
        {
            fill.value = 1f;
        }
      
    }
}
