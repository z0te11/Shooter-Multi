using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpeedAbilityTarget : AbilityTarget
{
    [SerializeField] private float _speed = 0.1f; 
    public override void Execute(GameObject target)
    {
        if (target == null) return;

        if (target.TryGetComponent<Movement>(out Movement m))
        {
            m.UpSpeed(_speed);
        }
    }
}
