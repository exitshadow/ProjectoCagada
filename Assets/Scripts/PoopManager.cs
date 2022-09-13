using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopManager : MonoBehaviour
{
    public GameObject poopPrefab;
    private int count = 0;
    private List<Transform> poopSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void CreatePoop()
    {
        GameObject instantiatePoop = Instantiate(poopPrefab, transform.position, Quaternion.identity);
        instantiatePoop.name = "Poop " + count.ToString();
        count++;
        print("Number of poops: " + count);

    }
}
