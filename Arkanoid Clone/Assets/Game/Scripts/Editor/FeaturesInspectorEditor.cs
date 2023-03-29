using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FeaturesInspector))]
public class FeaturesInspectorEditor : Editor
{
    SerializedProperty typeTween;
    int value = 0;
    private void OnEnable()
    {
        typeTween = serializedObject.FindProperty("typeTween");
    }
    public override void OnInspectorGUI()
    {
        FeaturesInspector myScript = (FeaturesInspector)target;
        serializedObject.Update();



        if(GUILayout.Button("Set Color"))
        {
            myScript.SetColorEvent();
        }
        GUILayout.Space(2);
        value = EditorGUILayout.IntSlider(value, 0, 3);
        GUILayout.Space(5);
        if(GUILayout.Button("Set Tweening"))
        {
            myScript.SetTweenEvent(value);
        }
    }
}
