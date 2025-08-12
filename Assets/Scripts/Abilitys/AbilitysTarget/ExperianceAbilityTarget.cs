using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExperianceAbilityTarget : AbilityTarget
{
    public int experianceValue;
    public List<GameObject> _playersGO;
    protected override void Awake()
    {
        Type = AbilityType.Exp;
    }
    public override void Execute(GameObject target)
    {
        _playersGO = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
        int newXP = experianceValue / _playersGO.Count;
        foreach (var player in _playersGO)
        {
            var e = player.GetComponent<ExperiancePlayer>();
            if (e)
            {
                e.AddExperiance(newXP);
                Debug.Log(newXP + player.ToString());
            }
        }
    }
}
