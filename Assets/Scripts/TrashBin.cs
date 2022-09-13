using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("To the bin it goes!");
    }
}
