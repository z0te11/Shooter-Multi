using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Die()
    {
        base.Die();
        GetComponent<BehaviourManager>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 5f);
    }
}
