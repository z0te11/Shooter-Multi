using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAbilityTarget : AbilityTarget
{
    [SerializeField] private TypeOfBuff _typeOfBuff;
    protected override void Awake()
    {
        Type = AbilityType.Buff;
    }

    public override void Execute(GameObject target)
    {
        var b = target.GetComponent<Buff>();
        if (b)
        {
            b.Execute(_typeOfBuff);
        }
    }
}
