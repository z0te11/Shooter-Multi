using System;
using UnityEngine;

public class StatisticCollector : MonoBehaviour
{
    public static Action<int> onShootDone;
    public static Action<int> onPickedBuff;
    public static Action<int> onPickedBuffDamage;
    public static Action<int> onPickedBuffArmor;
    public static Action<int> onPickedBuffSpeed;
    public static Action<int> onPickedBuffWeapon;
    public static Action<int> onKilledMobs;
    public static Action<int> onKilledSmallMobs;
    public static Action<int> onKilledMiddleMobs;
    public static Action<int> onKilledBigMobs;
    public static Action<int> onPointedPlayerChanged;
    private int _countShootPlayer;
    private int _countPickUpBuff;
    private int _countPickUpBuffDamage;
    private int _countPickUpBuffArmor;
    private int _countPickUpBuffSpeed;
    private int _countPickUpBuffWeapon;
    private int _countKillMobs;
    private int _countKillSmallMob;
    private int _countKillMiddleMob;
    private int _countKillBigEnemy;
    private int _countPointsPlayer;

    public static StatisticCollector instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        CountShootPlayer = 0;
        CountPickUpBuffDamage = 0;
        CountPickUpBuffArmor = 0;
        CountPickUpBuffSpeed = 0;
        CountPickUpBuffWeapon = 0;
        CountKillSmallMob = 0;
        CountKillMiddleMob = 0;
        CountKillBigMob = 0;

        CountKillMobs = 0;
        CountPickUpBuff = 0;
        CountPointsPlayer = 0;
    }
    public int CountShootPlayer
    {
        get { return _countShootPlayer; }
        set
        {
            _countShootPlayer = value;
            onShootDone?.Invoke(_countShootPlayer);
        }
    }

    public int CountPickUpBuff
    {
        get { return _countPickUpBuff; }
        set
        {
            _countPickUpBuff = value;
            onPickedBuff?.Invoke(_countPickUpBuff);
         }
    }

    public int CountPickUpBuffDamage
    {
        get { return _countPickUpBuffDamage;  }
        set
        {
            _countPickUpBuffDamage = value;
            CountPickUpBuff++;
            onPickedBuffDamage?.Invoke(_countPickUpBuffDamage);
         }
    }

    public int CountPickUpBuffArmor
    {
        get { return _countPickUpBuffArmor; }
        set
        {
            _countPickUpBuffArmor = value;
            CountPickUpBuff++;
            onPickedBuffArmor?.Invoke(_countPickUpBuffArmor);
         }
    }

    public int CountPickUpBuffSpeed
    {
        get { return _countPickUpBuffSpeed; }
        set
        {
            _countPickUpBuffSpeed = value;
            CountPickUpBuff++;
            onPickedBuffSpeed?.Invoke(_countPickUpBuffSpeed);
         }
    }

    public int CountPickUpBuffWeapon
    {
        get { return _countPickUpBuffWeapon; }
        set
        {
            _countPickUpBuffWeapon = value;
            CountPickUpBuff++;
            onPickedBuffWeapon?.Invoke(_countPickUpBuffWeapon);
         }
    }

    public int CountKillMobs
    {
        get { return _countKillMobs; }
        set
        {
            _countKillMobs = value;
            onKilledMobs?.Invoke(_countKillMobs);
         }
    }

    public int CountKillSmallMob
    {
        get { return _countKillSmallMob; }
        set
        {
            _countKillSmallMob = value;
            CountKillMobs++;
            CountPointsPlayer += 10;
            onKilledSmallMobs?.Invoke(_countKillSmallMob);
         }
    }

    public int CountKillMiddleMob
    {
        get { return _countKillMiddleMob; }
        set
        {
            _countKillMiddleMob = value;
            CountKillMobs++;
            CountPointsPlayer += 30;
            onKilledMiddleMobs?.Invoke(_countKillMiddleMob);
         }
    }

    public int CountKillBigMob
    {
        get { return _countKillBigEnemy; }
        set
        {
            _countKillBigEnemy = value;
            CountKillMobs++;
            CountPointsPlayer += 50;
            onKilledBigMobs?.Invoke(_countKillBigEnemy);
         }
    }

    public int CountPointsPlayer
    {
        get { return _countPointsPlayer; }
        set
        {
            _countPointsPlayer = value;
            onPointedPlayerChanged?.Invoke(_countPointsPlayer);
         }
    }
}
