using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridObject))]
public class GridObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridObject myScript = (GridObject)target;
        if (GUILayout.Button("Initialize Tiles"))
        {
            myScript.InitializeTiles();
        }
    }
}
