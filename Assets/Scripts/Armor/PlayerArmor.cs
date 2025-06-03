using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerArmor : Armor
{
    public Action<float> onPlayerArmorChanged;
    public Action<float> isPlayerArmorBuffed;

    public override float ArmorStat
    {
        get { return _armorStat; }
        set { if (value > 1) _armorStat = value; onPlayerArmorChanged?.Invoke(_armorStat); }
    }

    public override void BuffAbility(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseArmor)
        {
            ArmorStat += setBuff.valueBuff;
            Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
            StartCoroutine(EndingBuff(setBuff));
            isPlayerArmorBuffed?.Invoke(setBuff.timeBuff);
        }
    }

    public override void UnBuff(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseArmor)
        {
            ArmorStat -= setBuff.valueBuff;
            Debug.Log("Unbuff " + setBuff.typeOfBuff.ToString());
        }
    }
}
