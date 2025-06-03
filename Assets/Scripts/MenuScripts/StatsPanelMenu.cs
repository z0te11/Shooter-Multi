using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanelMenu : MonoBehaviour
{
    [SerializeField] private Text _damageStat;
    [SerializeField] private Text _speedDamageStat;
    [SerializeField] private Text _speedStat;
    [SerializeField] private Text _livesStat;
    [SerializeField] private Text _armorStat;

    public void ShowStats(PlayerStatsSettings playerStats)
    {
        _damageStat.text = "Урон " + playerStats.damageStat.ToString();
        _speedDamageStat.text = "Скорость атаки " + playerStats.speedDamageStat.ToString();
        _speedStat.text = "Скорость " + playerStats.speedStat.ToString();
        _livesStat.text = "Жизни " + playerStats.livesStat.ToString();
        _armorStat.text = "Защита " + playerStats.armorStat.ToString();
    }
}
