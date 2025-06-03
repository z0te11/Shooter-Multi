using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IType
{
    public AbilityType Type { get; set; }
    [SerializeField] protected Armor _armored;
    [SerializeField] protected OnDieManager onDieManager;
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected AnimController animController;

    public virtual float Healths
    {
        get { return _health; }
        set { _health = value; }
    }

    public virtual float MaxHealths
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    protected virtual void Awake()
    {
        Type = AbilityType.Health;
    }

    public virtual void SetHealth(int health)
    {
        MaxHealths = health;
        Healths = MaxHealths;
    }

    public virtual void IncreaseMaxHealth(float value)
    {
        MaxHealths += value;
        Healths += value;
    }
    public virtual void GetDamage(float damage)
    {
        if (_armored != null) Healths -= _armored.ReduceDamage(damage);
        else Healths -= damage;
        if (animController != null) animController.GetHit();
        if (_health <= 0) Die();
    }

    public virtual void GetHeal(float heal)
    {
        if (Healths + heal >= MaxHealths) Healths = MaxHealths;
        else Healths += heal;
    }

    public virtual void Die()
    {
        if (animController != null) animController.Die();
        if (onDieManager != null) onDieManager.Execute();
    }
}
