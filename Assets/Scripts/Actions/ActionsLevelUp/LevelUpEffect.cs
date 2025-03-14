using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour, ILevelUp
{
    public GameObject effect;
    public void LevelUp(ExperiancePlayer data, int level)
    {
        var newEffect = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(newEffect, 3f);
        Debug.Log("LevelUpEffect");
    }
}
