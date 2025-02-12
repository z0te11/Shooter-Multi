using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemAbility : ItemAbility, ICraftable
{
    [SerializeField] private int _heal;
    public string _name;
    public string Name => _name; 
    public override void Execute()
    {
        if (target == null) return;

        if (target.TryGetComponent<Health>(out Health h))
        {
            h.GetHeal(_heal);
        }
    }
}
