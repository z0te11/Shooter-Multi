using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperianceAbilityTarget : AbilityTarget
{
    public int experianceValue;
    protected override void Awake()
    {
        Type = AbilityType.Exp;
    }
    public override void Execute(GameObject target)
    {
        var e = target.GetComponent<ExperiancePlayer>();
        if (e)
        {
            e.AddExperiance(experianceValue);
            Debug.Log("PickUpExp");
        }
    }
}
