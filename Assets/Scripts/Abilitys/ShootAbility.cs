using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : Ability, IBuff
{
    public GameObject bullet;
    public float shootDelay;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _shootEffect;

    public Action<float> onPlayerDamageChanged;

    private float _shootTime = float.MinValue;
    private TypeOfBuff typeOfBuff;

    private void Awake()
    {
        typeOfBuff = TypeOfBuff.None;
    }
    public float Damage
    {
        get { return _damage; }
        set { _damage = value;
              onPlayerDamageChanged?.Invoke(_damage);}
    }

    public override void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;

        _shootTime = Time.time;
        Shoot();
    }

    private void Shoot()
    {
        if (_shootEffect != null) 
        {
            var bewShootEffect = Instantiate(_shootEffect, transform.position, transform.rotation, this.transform);
        }
        SpawnSystem.instance.SpawnBullet(bullet, this.transform, Damage, typeOfBuff);
    }

    public void BuffAbility(TypeOfBuff typeOfBuff)
    {
        this.typeOfBuff = typeOfBuff;
    }

    public void SetDamage(float value)
    {
        Damage = value;
    }

    public void UpDamage(float value)
    {
        Damage += value;
    }
}
