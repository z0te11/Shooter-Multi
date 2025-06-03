using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour, IBuff
{
    [SerializeField] protected float _armorStat = 1;

    public virtual float ArmorStat
    {
        get { return _armorStat; }
        set { if (value > 1) _armorStat = value; }
    }

    protected void Start()
    {
        if (TryGetComponent<CharacterData>(out CharacterData statsData))
        {
            ArmorStat = statsData.playerStatsSettings.armorStat;
        }
    }

    public float ReduceDamage(float damage)
    {
        float result = damage - _armorStat / 2f;
        return result;
    }
    
    public virtual void BuffAbility(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseArmor)
        {
            ArmorStat += setBuff.valueBuff;
            Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
            StartCoroutine(EndingBuff(setBuff));
        }
    }

    public virtual void UnBuff(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseArmor)
        {
            ArmorStat -= setBuff.valueBuff;
            Debug.Log("Unbuff " + setBuff.typeOfBuff.ToString());
        }
    }

    public IEnumerator EndingBuff(SettingsBuff setBuff)
    {
        yield return new WaitForSeconds(setBuff.timeBuff);
        UnBuff(setBuff);
    }
}
