using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using RoomGen;


[CustomEditor(typeof(TargetGenerator))]
public class TargetGeneratorEditor : Editor
{

    TargetGenerator targetGenerator;


    private void OnEnable()
    {
        targetGenerator = (TargetGenerator)target;
    }





    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();


        if (GUILayout.Button("Generate"))
        {

            targetGenerator.Generate();

        }


        if(GUI.changed)
        {
            targetGenerator.Generate();
        }
    }
}