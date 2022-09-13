using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopManager : MonoBehaviour
{
    public GameObject poopPrefab;
    private int count = 0;
    private List<CarmenBehaviour> poops = new List<CarmenBehaviour>();
    private List<CarmenBehaviour> poopsSpawned = new List<CarmenBehaviour>(10);

    // Start is called before the first frame update
    void Start()
    {
        CreatePoop(transform.position);
        StartCoroutine("WaitForNextPoop");
    }

    // Update is called once per frame

    IEnumerator WaitForNextPoop()
    {
        yield return new WaitForSeconds(2);
        for (var i = 0; i < poopsSpawned.Count; i++)
        {
            CreatePoop(transform.position);   
        }
        print("coroutine");  
    }

    private void CreatePoop(Vector3 position)
    {
        GameObject instantiatePoop = Instantiate(poopPrefab, position, Quaternion.identity);
        CarmenBehaviour poop = instantiatePoop.GetComponent<CarmenBehaviour>();
        poops.Add(poop);
            //poop.manager = this;

        count++;
        print("Number of poops: " + count);
        

    }
}
