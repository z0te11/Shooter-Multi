using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private Text _nameScene;
    [SerializeField] private Text _nameLevel;

    private void OnEnable()
    {
        LoadDataManager.OnDataSceneLoaded += SetSceneName;
        LoadDataManager.OnDataLevelLoaded += SetLevel;
    }

    private void OnDisable()
    {
        LoadDataManager.OnDataSceneLoaded -= SetSceneName;
        LoadDataManager.OnDataLevelLoaded -= SetLevel;
    }

    private void SetSceneName(string sceneName)
    {
        _nameScene.text = sceneName;
    }

    private void SetLevel(string level)
    {
        _nameLevel.text = level;
    }
}
