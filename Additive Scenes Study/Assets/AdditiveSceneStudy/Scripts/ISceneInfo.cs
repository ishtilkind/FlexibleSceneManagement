using System;

namespace TRIPSS
{
    public interface ISceneInfo
    {
        string SceneName { get; }
        SceneType SceneType { get; }
    }

    [Serializable]
    public class SceneManagerData : ISceneInfo
    {
        public SceneName sceneName;
        public SceneType sceneType;
        public string bundleName;
        public string SceneName => sceneName.ToString();
        public SceneType SceneType => sceneType;
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

}
