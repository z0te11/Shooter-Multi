using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerAbility : Ability
{
    public override void Execute()
    {
        Destroy(gameObject);
    }
}
