using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start()
    {
        UpdateCount();
    }

    void OnEnable()
    {
        Collect.OnCollected += OnCollectibleCollected;
    }

    void OnDisable()
    {
        Collect.OnCollected -= OnCollectibleCollected;
    }

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
        Collect.eatingAnimationCount++;

        if (count == Collect.total)
        {
            ReturnToMainMenu();
        }
    }

    void UpdateCount()
    {
        text.text = $"Hotdogs: {count} / {Collect.total}";
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("UI");
    }
}



