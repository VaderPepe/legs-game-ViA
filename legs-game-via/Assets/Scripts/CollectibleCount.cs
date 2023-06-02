using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    private bool isReturningToMainMenu = false; // Flag to indicate if returning to the main menu

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
        text.text = $"{count} / {Collect.total}";
    }

    void ReturnToMainMenu()
    {
        isReturningToMainMenu = true;
        SceneManager.LoadScene("UI");
    }

    void Update()
    {
        if (isReturningToMainMenu)
        {
            // Reset mouse position and unlock it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}


