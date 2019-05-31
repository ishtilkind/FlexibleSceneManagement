using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TRIPSS
{
    public class SimpleSceneManager : MonoBehaviour, ISceneManager
    {
        private readonly List<IManagedScene> registeredScenes = new List<IManagedScene>();

        [SerializeField] private volatile SceneManagerSettings sceneManagerSettings;

        public bool Register(IManagedScene managedScene)
        {
            if (registeredScenes.Contains(managedScene))
                return false;

            registeredScenes.Add(managedScene);
            return true;
        }

        public bool Unregister(IManagedScene managedScene)
        {
            if (!registeredScenes.Contains(managedScene))
                return false;

            registeredScenes.Remove(managedScene);
            return true;
        }
    }
}
