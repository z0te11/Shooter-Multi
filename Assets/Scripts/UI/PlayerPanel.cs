using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private Text _nameScene;
    [SerializeField] private Text _nameLevel;
    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _numberWaveText;

    private void OnEnable()
    {
        LoadDataManager.OnDataSceneLoaded += SetSceneName;
        LoadDataManager.OnDataLevelLoaded += SetLevel;
        MoneyController.OnMoneyChanged += SetMoneyText;
        WaveContorller.onWaveChanged += SetWaveText;
    }

    private void OnDisable()
    {
        LoadDataManager.OnDataSceneLoaded -= SetSceneName;
        LoadDataManager.OnDataLevelLoaded -= SetLevel;
        MoneyController.OnMoneyChanged -= SetMoneyText;
        WaveContorller.onWaveChanged -= SetWaveText;
    }

    private void SetSceneName(string sceneName)
    {
        _nameScene.text = sceneName;
    }

    private void SetLevel(string level)
    {
        _nameLevel.text = level;
    }

    private void SetMoneyText(int value)
    {
        _moneyText.text = value.ToString();
    }

    private void SetWaveText(int value)
    {
        _numberWaveText.text = "Волна: " +  value.ToString();
    }
}
