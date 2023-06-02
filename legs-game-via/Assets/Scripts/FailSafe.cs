using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FailSafe : MonoBehaviour
{
    public string mainMenuSceneName = "UI";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(mainMenuSceneName);
            UnlockMouseCursor();
        }
    }

    private void UnlockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
