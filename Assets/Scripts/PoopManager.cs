using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopManager : MonoBehaviour
{
    [HideInInspector] public List<Poop> activePoops = new List<Poop>();
    [HideInInspector] public List<Poop> thrownPoops = new List<Poop>();
    public GameObject poopPrefab;
    public GameObject carmen;
    public int maxCount = 20;
    private int count = 0;
    private bool poopsAreCleared = false;

    void Start()
    {
        if (carmen != null)
        {
            CreatePoop(transform.position);
            StartCoroutine("WaitForNextPoop");
        }
    }

    void Update()
    {
        if (count == maxCount) StopCoroutine("WaitForNextPoop");
        if (thrownPoops.Count == maxCount && !poopsAreCleared)
        {
            Debug.Log("You have cleared all the poops!");
            poopsAreCleared = true;
        }
    }

    IEnumerator WaitForNextPoop()
    {
        Debug.Log("enter coroutine");

        float randomFactor = Random.Range(.3f,1.5f);
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
        Poop poop = instantiatePoop.GetComponent<Poop>();
        activePoops.Add(poop);
        if(carmen != null) poop.poopManager = this;
        count++;
        print("Number of poops: " + count);
    }
}
