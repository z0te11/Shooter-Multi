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

    private float _shootTime = float.MinValue;
    private bool _isReflectBuff = false;

    public override void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;

        _shootTime = Time.time;
        Shoot();
    }

    private void Shoot()
    {
        if (bullet != null)
        {
            var t = transform;

            if (_shootEffect != null) 
            {
                var bewShootEffect = Instantiate(_shootEffect, t.position, t.rotation, this.transform);
            }
            
            var newBullet = Instantiate(bullet, t.position, t.rotation);

            if (_isReflectBuff)
            {
                Destroy(newBullet.GetComponent<DestroyerAbility>());
                ReflectAbility ra = newBullet.AddComponent(typeof(ReflectAbility)) as ReflectAbility;
            }
        }
    }

    public void BuffAbility(TypeOfBuff typeOfBuff)
    {
        _isReflectBuff = true;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
