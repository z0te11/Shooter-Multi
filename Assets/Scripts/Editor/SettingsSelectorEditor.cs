using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SettingsSelector))]
public class SettingsSelectorEditor : Editor
{
    private string[] settList;
    private SerializedProperty _settings;
    public int index = 0;

    private void OnEnable()
    {
        _settings = serializedObject.FindProperty("activeSettings");
    }

    public override void OnInspectorGUI()
    {
        settList = AssetDatabase.FindAssets("t:settings");
        string[] nameSettings = settList;
        for (int i = 0; i < nameSettings.Length; i++)
        {
            nameSettings[i] = AssetDatabase.GUIDToAssetPath(nameSettings[i]);
        }
        
        GUILayout.Label("Game Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);

        index = EditorGUILayout.Popup(index, settList);
        if (GUILayout.Button("Use"))
        {
            _settings.objectReferenceValue = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(settList[index]));
        }
        serializedObject.ApplyModifiedProperties();
    }
}
