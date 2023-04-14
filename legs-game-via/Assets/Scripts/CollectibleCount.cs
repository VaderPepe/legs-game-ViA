using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() => UpdateCount();

    void OnEnable() => Collect.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collect.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
        FindObjectOfType<FirstPersonController>().jumpHeightMultiplier += 0.1f;
    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collect.total}";
    }
}
