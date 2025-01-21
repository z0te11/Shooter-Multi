using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IType
{
    public AbilityType Type { get; set; }
    [SerializeField] protected int _health;

    public virtual int Healths
    {
        get { return _health; }
        set { _health = value; }
    }

    protected void Awake()
    {
        Type = AbilityType.Health;
    }

    public virtual void SetHealth(int health)
    {
        Healths = health;
    }
    public virtual void GetDamage(int damage)
    {
        Healths -= damage;
        Debug.Log("GetDamage" + _health);
        if (_health < 0) Die();
    }

    public virtual void GetHeal(int heal)
    {
        Healths += heal;
        Debug.Log("GetHeal" + _health);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
