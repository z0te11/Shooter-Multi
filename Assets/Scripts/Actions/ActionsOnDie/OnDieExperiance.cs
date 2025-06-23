using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnDieExperiance : MonoBehaviour, IDie
{
    public int experianceValue;
    private List<GameObject> _playersGO;

    private void Awake()
    {
        _playersGO = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
    }
    public void OnDie()
    {
        int newXP = experianceValue / _playersGO.Count;
        foreach (var player in _playersGO)
        {
            player.GetComponent<ExperiancePlayer>().AddExperiance(newXP);
        }

    }

}
