using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FeaturesInspector))]
public class FeaturesInspectorEditor : Editor
{
    int TweenValue = 0;
    bool randomizer;
    public override void OnInspectorGUI()
    {
        FeaturesInspector myScript = (FeaturesInspector)target;



        if(GUILayout.Button("Set Color"))
        {
            myScript.SetColorEvent();
        }
        GUILayout.Space(5);
        randomizer = GUILayout.Toggle(randomizer, "Randomizer");
        GUILayout.Space(2);
        TweenValue = EditorGUILayout.IntSlider(TweenValue, 0, 3);
        GUILayout.Space(5);
        if(GUILayout.Button("Set Tweening"))
        {
            myScript.SetTweenEvent(TweenValue, randomizer);
        }
    }
}
