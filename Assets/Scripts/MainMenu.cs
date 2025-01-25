using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1.0f; // for future animations
    public void OnButtonClick(string sceneName)
    {
        StartCoroutine(LoadNextScene(sceneName));
    }
    IEnumerator LoadNextScene(string sceneName)
    {
        yield return new WaitForSeconds(animationDuration);

        if (sceneName == "Prologue") //Going to be changing in the future
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName == "Quit")
        {
            Application.Quit();
        }
    }
}
