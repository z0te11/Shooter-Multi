using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour, IType
{
    public AbilityType Type { get; set; }

    protected Ability[] _abilities;

    protected void  Awake()
    {
        Type = AbilityType.Buff;
    }

    protected void Start()
    {
        _abilities = GetComponents<Ability>();
    }

    public void Execute(TypeOfBuff typeOfBuff)
    {
        switch (typeOfBuff)
        {
            case TypeOfBuff.Reflect:
            {
                BuffReflect();
                break;
            }
            default:
            {
                return;
            }
        }
    }

    private void BuffReflect()
    {
        for (int i = 0; i < _abilities.Length; i++)
        {
            var a = _abilities[i].GetComponent<IBuff>();
            if (a != null)
            {
                a.BuffAbility(TypeOfBuff.Reflect);
            }
        }
    }


}
