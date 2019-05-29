using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScene : MonoBehaviour
{
    private Scene scene;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    IEnumerator Start()
    {
        Debug.Log($"{scene.name} is Loaded");
        yield return StartCoroutine(UnloadMainScene());
    }

    IEnumerator UnloadMainScene()
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync("Main");

        // Wait until the asynchronous scene fully loads
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
}
