using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : Ability, IItem
{
    public GameObject _UIItem;

    public GameObject UIItem => _UIItem;

    public override void Execute()
    {
        GameManager.instance.inventar.CreateItem(_UIItem);
    }

}
