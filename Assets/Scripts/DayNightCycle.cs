using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    
    //public GameObject pivot;
    public bool canRotate;
    
    Vector3 cycle;
    public float degreesPerSecond = 0.02f;

    void Start()
    {
        //transform.RotateAround(pivot.transform.position, Vector3.right, 20 * Time.deltaTime);
    } 
    void Update()
    {
        StartRotate();
    }

    public void StartRotate()
    {
        canRotate = true;
        Vector3 endCycle = new Vector3(179f, 30 , 0);
        if (canRotate) 
        {
            cycle = new Vector3(degreesPerSecond, 0, 0);
            transform.Rotate(cycle, Space.World);
        }
        if(canRotate == false)
        {
            cycle = endCycle;
        }
    } 
}
