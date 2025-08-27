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
            WriteInStatistic(settingsBuff.typeOfBuff);
        }
    }

    private void WriteInStatistic(TypeOfBuff typeBuff)
    {
        switch (typeBuff)
        {
            case TypeOfBuff.IncreaseDamage:
                {
                    StatisticCollector.instance.CountPickUpBuffDamage++;
                    break;
                }
            case TypeOfBuff.IncreaseArmor:
                {
                    StatisticCollector.instance.CountPickUpBuffArmor++;
                    break;
                }
            case TypeOfBuff.IncreaseSpeed:
                {
                    StatisticCollector.instance.CountPickUpBuffSpeed++;
                    break;
                }
            case TypeOfBuff.IncreaseWeapon:
                {
                    StatisticCollector.instance.CountPickUpBuffWeapon++;
                    break;
                }
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
