using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTo : MonoBehaviour
{
    public void LoadScene(string nextSceneName)
    {
        StartCoroutine(LoadNextScene(nextSceneName));
    }

    IEnumerator LoadNextScene(string nextSceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync("Settings");
    }
}
