using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collect : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    public static int eatingAnimationCount;

    private float scaleDuration = 1f; // Duration of the scaling animation
    private float scaleTimer = 0f; // Timer for the scaling animation
    private bool scalingOut = false; // Flag to indicate if scaling out is in progress
    private Vector3 initialScale; // Initial scale of the object

    void Awake()
    {
        total++;
    }

    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);

        if (scalingOut)
        {
            scaleTimer += Time.deltaTime;
            float t = scaleTimer / scaleDuration;
            float scale = Mathf.Lerp(1f, 0f, t);
            transform.localScale = initialScale * scale;

            if (scaleTimer >= scaleDuration)
            {
                OnCollected?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !scalingOut)
        {
            scalingOut = true;
        }
    }
}

