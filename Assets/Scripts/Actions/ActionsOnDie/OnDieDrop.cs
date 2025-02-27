using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieDrop : MonoBehaviour, IDie
{
    public DropSettings dropSettings;

    public void OnDie()
    {
        int i = Random.Range(0, dropSettings.dropItems.Length);
        SpawnSystem.instance.SpawnPickUp(dropSettings.dropItems[i], transform);
    }
}
