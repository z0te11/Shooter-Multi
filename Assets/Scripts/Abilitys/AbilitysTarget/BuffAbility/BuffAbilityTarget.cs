using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAbilityTarget : AbilityTarget
{
    public SettingsBuff settingsBuff;
    protected override void Awake()
    {
        Type = AbilityType.Buff;
    }

    public override void Execute(GameObject target)
    {
        var b = target.GetComponent<Buff>();
        if (b)
        {
            b.Execute(settingsBuff);
        }
    }

}

    [System.Serializable]
    public struct SettingsBuff
    {
        public float valueBuff;
        public float timeBuff;
        public TypeOfBuff typeOfBuff;
    }
