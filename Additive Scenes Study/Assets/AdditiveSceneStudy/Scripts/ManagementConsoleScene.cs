using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagementConsoleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UnloadScene()
    {
        StartCoroutine(UnloadConsoleScene());
    }

    IEnumerator UnloadConsoleScene()
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync("ManagementConsoleUI");

        // Wait until the asynchronous scene fully loads
        while (!asyncUnload.isDone)
        {
            yield return null;
        }

        Debug.Log($"ManagementConsoleUI scene is unloaded.");
    }

    public void PrintAllScenes()
    {
        for (var index = 0; index < SceneManager.sceneCount; ++index)
        {
            Debug.Log($"'{SceneManager.GetSceneAt(index).name}'");
        }
    }
}
