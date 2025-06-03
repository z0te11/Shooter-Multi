using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour, IType
{
    public AbilityType Type { get; set; }
    protected IBuff[] _buffComp;

    protected void Awake()
    {
        Type = AbilityType.Buff;
    }

    protected void Start()
    {
        _buffComp = GetComponents<IBuff>();
    }

    public void Execute(SettingsBuff setBuff)
    {
        for (int i = 0; i < _buffComp.Length; i++)
        {
            _buffComp[i].BuffAbility(setBuff);
        }
    }

}
