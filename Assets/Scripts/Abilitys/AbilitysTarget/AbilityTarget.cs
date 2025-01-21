using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityTarget : MonoBehaviour, IType
{
    public AbilityType Type { get; set; }

    protected virtual void Awake()
    {
        Type = AbilityType.Health;
    }
    public virtual void Execute(GameObject target)
    {
        
    }
}


