using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpeedItemAbility : ItemAbility, ICraftable
{
    [SerializeField] private int _speed; 
    public string _name;
    public string Name => _name; 
    public override void Execute()
    {
        if (target == null) return;

        if (target.TryGetComponent<Movement>(out Movement m))
        {
            m.UpSpeed(_speed);
        }
    }
}
