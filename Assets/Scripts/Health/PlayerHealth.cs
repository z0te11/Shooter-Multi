using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override int Healths
    {
        get { return _health; }
        set { _health = value;}
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
