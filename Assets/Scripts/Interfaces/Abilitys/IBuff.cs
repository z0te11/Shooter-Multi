using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
    public void BuffAbility(SettingsBuff settingsBuff);

    public void UnBuff(SettingsBuff settingsBuff);
    public IEnumerator EndingBuff(SettingsBuff settingsBuff);
}
