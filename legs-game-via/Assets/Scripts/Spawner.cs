using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject hiddenObject;
    public float revealTime = 5f;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player")) // Assuming the trigger platform has a "Player" tag
        {
            Debug.Log("Collided");
            StartCoroutine(RevealObject());
        }
    }

    private IEnumerator RevealObject()
    {
        isTriggered = true;
        hiddenObject.SetActive(true);

        yield return new WaitForSeconds(revealTime);

        hiddenObject.SetActive(false);
        isTriggered = false;
    }
}
