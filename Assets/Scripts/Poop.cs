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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter trigger");
        if(other.CompareTag("TrashBinHitBox"))
        {
            Debug.Log("Poop is thrown in the bin");
            if (poopManager !=null) poopManager.poops.Remove(this);
            StartCoroutine("WaitToTrash", lag);
        }
    }
}
