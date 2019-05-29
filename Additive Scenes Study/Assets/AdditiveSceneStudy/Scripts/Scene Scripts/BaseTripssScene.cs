using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTripssScene : MonoBehaviour
{
    protected Action<string> onLoaded;
    protected Action<string> onUnloaded;
    [SerializeField] protected int backToIndex = -1;
    protected virtual void OnEnable()
    {
        onLoaded?.Invoke(name);
    }

    protected virtual void OnDisable()
    {
        onUnloaded?.Invoke(name);
    }
}
