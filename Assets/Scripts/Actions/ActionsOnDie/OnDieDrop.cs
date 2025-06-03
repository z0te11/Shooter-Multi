using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieDrop : MonoBehaviour, IDie
{
    public DropSettings dropSettings;
    public void OnDie()
    {
        int maxDrop = 1;

        if (WaveContorller.instance.CountWave > dropSettings.dropItems.Length) maxDrop = dropSettings.dropItems.Length;
        else maxDrop = WaveContorller.instance.CountWave;

        int i = Random.Range(0, maxDrop);
        SpawnSystem.instance.SpawnPickUp(dropSettings.dropItems[i], transform);
    }
}
