using System;
using System.Collections;
using UnityEngine;

public class ShootPlayerAbility : ShootAbility, IReload
{
    public Action<float> onPlayerDamageChanged;
    public Action<int, int> onPlayerAmmoChanged;
    public Action<bool> onPlayerReloading;
    public Action<float> isPlayerDamageBuffed;
    public Action<float> isPlayerWeaponBuffed;

    [SerializeField] public int startAmmoCount;
    [SerializeField] public float startTimeReload;

    public int curAmmoCount;
    public bool isReloading = false;



    public override float Damage
    {
        get { return _damage; }
        set
        {
            _damage = value;
            onPlayerDamageChanged?.Invoke(_damage);
        }
    }

    private void Start()
    {
        Reload();
        if (TryGetComponent<CharacterData>(out CharacterData statsData))
        {
            Damage = statsData.playerStatsSettings.damageStat;
            shootDelay = statsData.playerStatsSettings.speedDamageStat;
        }
    }

    public override void Execute()
    {
        if (isReloading) return;
        if (Time.time < _shootTime + shootDelay) return;

        _shootTime = Time.time;
        Shoot();
    }

    protected override void Shoot()
    {
        if (TryShootAmmo())
        {
            if (_shootEffect != null)
            {
                var bewShootEffect = Instantiate(_shootEffect, transform.position, transform.rotation, this.transform);
            }
            SpawnSystem.instance.SpawnBullet(bullet, this.transform, Damage);
            StatisticCollector.instance.CountShootPlayer++;
            // FMODUnity.RuntimeManager.PlayOneShot( "event:/Shoot" );
        }
    }

    private bool TryShootAmmo()
    {
        if (curAmmoCount > 0)
        {
            curAmmoCount--;
            onPlayerAmmoChanged?.Invoke(curAmmoCount, startAmmoCount);
            return true;
        }
        else if (!isReloading)
        {
            Reload();
            return false;
        }
        return false;
    }

    public void Reload()
    {
        if (curAmmoCount >= startAmmoCount ^ isReloading) return;
        isReloading = true;
        onPlayerReloading?.Invoke(isReloading);
        StartCoroutine(Reloading(startTimeReload));
    }

    private IEnumerator Reloading(float sec)
    {
        yield return new WaitForSeconds(sec);
        curAmmoCount = startAmmoCount;
        isReloading = false;
        onPlayerAmmoChanged?.Invoke(curAmmoCount, startAmmoCount);
        onPlayerReloading?.Invoke(isReloading);
    }

    public override void UnBuff(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseDamage)
        {
            this._settingBuffs.Remove(setBuff);
            Damage -= setBuff.valueBuff;
        }
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseWeapon)
        {
            this._settingBuffs.Remove(setBuff);
            shootDelay += setBuff.valueBuff;
            startTimeReload += setBuff.valueBuff;
        }
        Debug.Log("Unbuff " + setBuff.typeOfBuff.ToString());
    }
    
    protected override void BuffIncreaseWeapon(SettingsBuff setBuff)
    {
        this._settingBuffs.Add(setBuff);
        shootDelay -= setBuff.valueBuff;
        startTimeReload -= setBuff.valueBuff;
        StartCoroutine(EndingBuff(setBuff));
        isPlayerWeaponBuffed?.Invoke(setBuff.timeBuff);
        Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
    }
    protected override void BuffIncreaseDamage(SettingsBuff setBuff)
    {
        this._settingBuffs.Add(setBuff);
        Damage += setBuff.valueBuff;
        StartCoroutine(EndingBuff(setBuff));
        isPlayerDamageBuffed?.Invoke(setBuff.timeBuff);
        Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
    }
}
