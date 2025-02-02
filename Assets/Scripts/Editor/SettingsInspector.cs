using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Settings))]
public class SettingsInspector: Editor
{
    private SerializedProperty _health;
    private bool _setHealth;

    private void OnEnable()
    {
        _health = serializedObject.FindProperty("healthEnemy");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();
        GUILayout.Label(_health.intValue.ToString());
        _setHealth = GUILayout.Button("Set Health back to 20");
        if (_setHealth)
        {
            _health.intValue = 20;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
