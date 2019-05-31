using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace TRIPSS
{
    public class InitScene : BaseTripssScene
    {
        [SerializeField] private string nextSceneName;

        [SerializeField] private volatile SettingsApplication appSettings;
        [SerializeField] private volatile SceneManagerSettings sceneManagerSettings;
        [SerializeField] private volatile ManagementConsoleScene managementConsoleScene;

        //protected override void OnEnable()
        //{
        //    base.OnEnable();
        //    Debug.Log($"OnEnable called from {name}");
        //}

        //protected override void OnDisable()
        //{
        //    base.OnDisable();
        //    Debug.Log($"OnDisable called from {name}");
        //}

        private IEnumerator Start()
        {
            yield return StartCoroutine(Initialize());
        }

        // Update is called once per frame
        IEnumerator Initialize()
        {
            if (null == appSettings || null == sceneManagerSettings)
            {
                yield return StartCoroutine(LoadExternalSettingsAsync(onFinishedLoadingExtrernalResources));
            }
            else
            {
                onFinishedLoadingExtrernalResources();
            }
        }

        private void onFinishedLoadingExtrernalResources()
        {
            if (null != appSettings)
            {
                var cam = Camera.main;
                cam.backgroundColor = appSettings.CameraBackgroundColor;
            }

            StartCoroutine(LoadNextScene());
        }

        IEnumerator LoadNextScene()
        {
            if (null != sceneManagerSettings)
            {
                nextSceneName = sceneManagerSettings.internalScenes[sceneManagerSettings.bootstrapIndex].sceneName
                    .ToString();
            }

            SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
            yield return null;
        }

        private IEnumerator LoadExternalSettingsAsync(Action onFinished)
        {
            var url = Path.Combine(Application.streamingAssetsPath, "settings");
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

                    if (bundle != null)
                    {
                        if (null == appSettings && bundle.Contains("AppSettings"))
                        {
                            appSettings = bundle.LoadAsset<SettingsApplication>("AppSettings");
                        }

                        if (null == sceneManagerSettings && bundle.Contains("SceneManagerSettings"))
                        {
                            sceneManagerSettings = bundle.LoadAsset<SceneManagerSettings>("SceneManagerSettings");
                        }
                    }

                }

                onFinished?.Invoke();
            }

            // yield return LoadExternalUtilityScenesAsync(onFinished);
        }

        private IEnumerator LoadExternalUtilityScenesAsync(Action onFinished)
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

                    if (bundle != null)
                    {
                        if (null == appSettings && bundle.Contains("ManagementConsoleUI"))
                        {
                            managementConsoleScene = bundle.LoadAsset<ManagementConsoleScene>("ManagementConsoleUI");
                        }
                    }

                }

                onFinished?.Invoke();
            }
        }

    }
}
