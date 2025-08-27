using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : Ability, IBuff
{
    public GameObject bullet;
    [SerializeField] protected float _shootDelay;
    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected float _damage;
    protected float _shootTime = float.MinValue;
    protected List<SettingsBuff> _settingBuffs = new List<SettingsBuff>();

    public virtual float ShootDelay
    {
        get { return _shootDelay; }
        set
        {
            if (value > 0.1f) _shootDelay = value;
            else _shootDelay = 0.1f;
        }        
    }
    public virtual float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public override void Execute()
    {
        if (Time.time < _shootTime + ShootDelay) return;

        _shootTime = Time.time;
        Shoot();
    }

    protected virtual void Shoot()
    {
        if (_shootEffect != null) 
        {
            var bewShootEffect = Instantiate(_shootEffect, transform.position, transform.rotation, this.transform);
        }
        SpawnSystem.instance.SpawnBullet(bullet, this.transform, Damage);
    }

    public void BuffAbility(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseDamage)
        {
            BuffIncreaseDamage(setBuff);
        }
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseWeapon)
        {
            BuffIncreaseWeapon(setBuff);
        }
    }
    
    protected virtual void BuffIncreaseWeapon(SettingsBuff setBuff)
    {
        this._settingBuffs.Add(setBuff);
        ShootDelay -= setBuff.valueBuff;
        StartCoroutine(EndingBuff(setBuff));
        Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
    }
    protected virtual void BuffIncreaseDamage(SettingsBuff setBuff)
    {
        this._settingBuffs.Add(setBuff);
        Damage += setBuff.valueBuff;
        StartCoroutine(EndingBuff(setBuff));
        Debug.Log("Buff " + setBuff.typeOfBuff.ToString());
    }

    public virtual void UnBuff(SettingsBuff setBuff)
    {
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseDamage)
        {
            this._settingBuffs.Remove(setBuff);
            Damage -= setBuff.valueBuff;
        }
        if (setBuff.typeOfBuff == TypeOfBuff.IncreaseWeapon)
        {
            this._settingBuffs.Remove(setBuff);
            ShootDelay += setBuff.valueBuff;
        }
        Debug.Log("Unbuff " + setBuff.typeOfBuff.ToString());
    }

    public IEnumerator EndingBuff(SettingsBuff setBuff)
    {
        yield return new WaitForSeconds(setBuff.timeBuff);
        UnBuff(setBuff);
    }

    public void SetDamage(float value)
    {
        Damage = value;
    }

    public void SetShootDelay(float value)
    {
        ShootDelay = value;
    }

    public void UpDamage(float value)
    {
        Damage += value;
    }
}
