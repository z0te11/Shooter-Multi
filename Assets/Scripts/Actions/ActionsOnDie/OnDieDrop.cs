using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieDrop : MonoBehaviour, IDie
{
    public DropSettings dropSettings;

    public void OnDie()
    {
        int i = Random.Range(0, dropSettings.dropItems.Length);
        var newItem = Instantiate(dropSettings.dropItems[i], transform.position, Quaternion.identity);
    }
}
