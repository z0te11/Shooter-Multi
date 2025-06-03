using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : Movement, IBuff
{
    public Action<float> onPlayerSpeedChanged;
    public Action<float> isPlayerSpeedBuffed;

    public override float Speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            onPlayerSpeedChanged?.Invoke(_speed);
        }
    }
    public void BuffAbility(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseSpeed)
        {
            Speed += setBuff.valueBuff;
            Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
            isPlayerSpeedBuffed?.Invoke(setBuff.timeBuff);
            StartCoroutine(EndingBuff(setBuff));
        }
    }

    public void UnBuff(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseSpeed)
        {
            Speed -= setBuff.valueBuff;
            Debug.Log("Unbuff " + setBuff.typeOfBuff.ToString());
        }
    }

    public IEnumerator EndingBuff(SettingsBuff setBuff)
    {
        yield return new WaitForSeconds(setBuff.timeBuff);
        UnBuff(setBuff);
    }
}
