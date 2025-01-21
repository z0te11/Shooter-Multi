using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbilityTarget : AbilityTarget
{
    public int damage = 10;
    
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public override void Execute(GameObject target)
    {
        var h = target.GetComponent<Health>();
        if (h)
        {
            h.GetDamage(damage);
        }
    }
}
