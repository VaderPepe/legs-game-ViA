using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatingCount : MonoBehaviour
{
    public static int eatingAnimationCount;
    private TMPro.TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start()
    {
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"Hotdogs left: {eatingAnimationCount}";
    }
}