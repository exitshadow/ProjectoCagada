using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject carmen;
    public List<GameObject> fruitsPrefab;
    public List<Transform> spawnPoint;
    public float Timer = 15f;

    void Start()
    {
        CreateFruit();
    }
    private void CreateFruit()
    {
        if(Timer == 0){
            GameObject instantiateFruit = Instantiate(fruitsPrefab[Random.Range(0,8)], spawnPoint[Random.Range(0,10)].position, Quaternion.identity); //rotation neutre
        }
    }
}
