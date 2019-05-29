using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneManagerSettings", menuName = "ScriptableObjects/Scene Manager Data", order = 2)]
public class SceneManagerSettings : ScriptableObject
{
    public SceneManagerData[] sceneManagerData;
    public int bootstrapIndex;
}

[Serializable]
public class SceneManagerData
{
    public SceneName sceneName;
    public SceneType sceneType;
    public string bundleName;
}


[Serializable]
public enum SceneName
{
    Init,
    Main,
    Settings,
    ManagementConsoleUI
}

[Serializable]
public enum SceneType
{
    Internal,
    External,
}



