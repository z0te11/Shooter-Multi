using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpHealth : MonoBehaviour, ILevelUp
{
    public float upHealth;
    private Health _healthComp;
    public void LevelUp(ExperiancePlayer data, int level)
    {
        if (_healthComp == null)
        {
            _healthComp = GetComponent<Health>();
            if (_healthComp != null) return;
        }
        _healthComp.IncreaseMaxHealth(upHealth);
    }
}
