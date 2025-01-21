using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectAbility : Ability
{
    public override void Execute()
    {
        var m = GetComponent<Movement>();
        if (m != null) m.ChangeDir();
    }

}
