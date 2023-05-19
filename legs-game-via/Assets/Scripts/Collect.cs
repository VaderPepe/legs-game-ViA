using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    public static int eatingAnimationCount;

    //private AudioSource audioSource;

    void Awake()
    {
        total++;
    }

    // private void Start()
    // {
    //     audioSource = FindObjectOfType<AudioSource>();
    // }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //audioSource.Play();
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
