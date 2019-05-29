using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    private Scene scene;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{scene.name} is Loaded");
    }

    public void LoadPanel()
    {
        StartCoroutine(LoadPanelSceneAsync());

    }

    private IEnumerator LoadPanelSceneAsync()
    {
        var url = Path.Combine(Application.streamingAssetsPath, "management_console");
        Debug.Log(url);

        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);

                if (bundle.isStreamedSceneAssetBundle)
                {
                    string[] scenePaths = bundle.GetAllScenePaths();
                    string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePaths[0]);
                    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                }

            }
        }
    }
}
