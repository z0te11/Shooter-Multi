using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDamageAbilityTarget : AbilityTarget
{
    [SerializeField] private float _damage = 0.1f; 
    public override void Execute(GameObject target)
    {
        if (target == null) return;

        if (target.TryGetComponent<ShootAbility>(out ShootAbility s))
        {
            s.UpDamage(_damage);
        }
    }
}
