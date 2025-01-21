using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbilityTarget : AbilityTarget
{
    public int heal = 10;
    
    public override void Execute(GameObject target)
    {
        var h = target.GetComponent<Health>();
        if (h)
        {
            h.GetHeal(heal);
        }
    }
}
