using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;    

public class TeleportationScript : MonoBehaviour
{
    public Transform teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            FirstPersonController firstPersonController = other.GetComponentInParent<FirstPersonController>();

            // Disable player controls
            firstPersonController.enabled = false;

            // Teleport the player
            other.transform.position = teleportLocation.position;

            // Re-enable player controls
            firstPersonController.enabled = true;
        }
    }
}

