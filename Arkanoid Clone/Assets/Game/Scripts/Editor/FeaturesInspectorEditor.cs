using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FeaturesInspector))]
public class FeaturesInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FeaturesInspector myScript = (FeaturesInspector)target;

        if(GUILayout.Button("Set Color"))
        {
            myScript.SetColorEvent();
        }
    }
}
