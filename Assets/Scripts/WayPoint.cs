using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public List<WayPoint> wayPoints;
    public float radius = 1f;

    void Start(){
        foreach(WayPoint wp  in GameObject.FindObjectsOfType<WayPoint>()){
            if(wp == this) continue;

            if(Vector3.Distance(transform.position, wp.transform.position) <= radius){
                wayPoints.Add(wp);
            }
        }
    }
    public WayPoint GetNextWayPoint(){
        if(wayPoints.Count == 0) return null;
        int index = Random.Range(0, wayPoints.Count);
        return wayPoints[index];
    }
}
