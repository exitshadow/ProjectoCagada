using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public float lag = 1f;
    public PoopManager poopManager;

    IEnumerator WaitToTrash(float lag)
    {
        yield return new WaitForSeconds(lag);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        if (poopManager.carmen == null)
        {
            poopManager.activePoops.Add(this);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter trigger");
        if(other.CompareTag("TrashBinHitBox"))
        {
            Debug.Log("Poop is thrown in the bin");
            if (poopManager !=null)
            {
                poopManager.activePoops.Remove(this);
                poopManager.thrownPoops.Add(this);
                Debug.Log($"You have thrown {poopManager.thrownPoops.Count} poops!");
            }
            StartCoroutine("WaitToTrash", lag);
        }
    }
}
