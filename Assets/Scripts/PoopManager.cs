using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopManager : MonoBehaviour
{
    public GameObject poopPrefab;
    public GameObject carmen;
    private int count = 0;
    private List<CarmenBehaviour> poops = new List<CarmenBehaviour>();
    private List<CarmenBehaviour> poopsSpawned = new List<CarmenBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        CreatePoop(transform.position);
        StartCoroutine("WaitForNextPoop");
    }

    // Update is called once per frame

    IEnumerator WaitForNextPoop()
    {
        float randomFactor = Random.Range(.3f,1.5f);
        Debug.Log("enter coroutine");
        while(true)
        {
            yield return new WaitForSeconds(1 + randomFactor);
            CreatePoop(carmen.transform.position);   
            print("poop");  
        }
    }

    private void CreatePoop(Vector3 position)
    {
        GameObject instantiatePoop = Instantiate(poopPrefab, position, carmen.transform.rotation);
        CarmenBehaviour poop = instantiatePoop.GetComponent<CarmenBehaviour>();
        poops.Add(poop);
            //poop.manager = this;

        count++;
        print("Number of poops: " + count);
        

    }
}
