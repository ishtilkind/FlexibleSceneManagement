using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AppSettings", menuName = "ScriptableObjects/Application Settings", order = 1)]
public class SettingsApplication : ScriptableObject
{
    public Color CameraBackgroundColor = Color.blue;
}

