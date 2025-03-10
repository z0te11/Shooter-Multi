using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour, ILevelUp
{
    public GameObject effect;
    public AK.Wwise.Event lvlUpEvent = null;
    public void LevelUp(ExperiancePlayer data, int level)
    {
        if (lvlUpEvent != null) lvlUpEvent.Post(this.gameObject);
        var newEffect = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(newEffect, 3f);
        Debug.Log("LevelUpEffect");
    }
}
