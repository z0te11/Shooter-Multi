using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHealth : Health
{
    public Action<int> onPlayerHealthChanged;
    public override int Healths
    {
        get { return _health; }
        set { _health = value;
              onPlayerHealthChanged?.Invoke(_health);}
    }

    public override void SetHealth(int health)
    {
        Healths = health;
    }

    public override void Die()
    {
        base.Die();
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

}
