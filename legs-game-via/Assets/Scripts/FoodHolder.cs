using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class FoodHolder : MonoBehaviour
{
    public GameObject Hotdog;
    public bool canEat = true;
    public float eatCD = 2.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (canEat)
            {
                HotdogEat();
            }
        }
    }

    public void HotdogEat()
{
    if (Collect.eatingAnimationCount > 0)
    {
        canEat = false;
        Animator anim = Hotdog.GetComponent<Animator>();
        anim.SetTrigger("Eat");
        StartCoroutine(ResetEatCD());
        FirstPersonController fpc = FindObjectOfType<FirstPersonController>();
        fpc.jumpHeightMultiplier += 0.8f; // Increase jump height
        Collect.eatingAnimationCount--;
    }
}

    IEnumerator ResetEatCD()
    {
        yield return new WaitForSeconds(eatCD);
        canEat = true;
    }
}
