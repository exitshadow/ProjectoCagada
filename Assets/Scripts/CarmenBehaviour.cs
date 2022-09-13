using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarmenBehaviour : MonoBehaviour
{
    public enum State { walking, eating }
    private NavMeshAgent agent;
    public State status = State.walking;
    public Transform fruitTransform, waypointTransform, groupTransform, centerEye;

    public PoopManager manager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetNewDestination();
    }

    private void GetNewDestination() {
        Transform currentDestination = waypointTransform;

        do {
            int index = Random.Range(0, groupTransform.childCount);
            waypointTransform = groupTransform.GetChild(index);
        } while(waypointTransform == currentDestination);

        agent.SetDestination(waypointTransform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform == waypointTransform) {
            GetNewDestination();
        }
    }

    private bool DetectFruit(){
        Vector3 direction = fruitTransform.position - centerEye.position;
        direction = direction.normalized;

        float angle = Vector3.Angle(centerEye.forward, direction);

        if (angle <= 45) {
            RaycastHit raycasthit;
            Debug.DrawRay(centerEye.position, direction * 100, Color.red, 1f);

            if(Physics.Raycast(centerEye.position, direction, out raycasthit)){
                Debug.Log($"Hit: {raycasthit.transform.name}");
                if(raycasthit.transform == fruitTransform){
                    return true;
                }
            }
        }
        return false;
    }

    void UpdateWalking(){
        if(DetectFruit()){
            status = State.eating;
        }
    }

    void UpdateEating(){
        agent.SetDestination(fruitTransform.position);
        if(!DetectFruit()){
            status = State.walking;
            GetNewDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case State.walking: UpdateWalking(); break;
            case State.eating: UpdateEating(); break; 
        }
    }
}
