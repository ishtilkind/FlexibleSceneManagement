using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TRIPSS
{
    public abstract class BaseTripssScene : MonoBehaviour, IManagedScene
    {
        protected Action<string> onLoaded;
        protected Action<string> onUnloaded;
        [SerializeField] protected int backToIndex = -1;

        protected virtual void OnEnable()
        {
            SceneLoaded();
        }

        protected virtual void OnDisable()
        {
            SceneUnloaded();
        }

        public void SceneLoaded()
        {
            onLoaded?.Invoke(name);
        }

        public void SceneUnloaded()
        {
            onUnloaded?.Invoke(name);
        }
    }
}
