using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TRIPSS
{
    [CreateAssetMenu(fileName = "SceneManagerSettings", menuName = "ScriptableObjects/Scene Manager Data", order = 2)]
    public class SceneManagerSettings : ScriptableObject
    {
        public SceneManagerData[] internalScenes;
        public SceneManagerData[] externalScenes;
        public int bootstrapIndex;
    }
}



