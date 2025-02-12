using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiancePlayer: MonoBehaviour, IExp, IType
{
    public AbilityType Type { get; set; }
    public List<MonoBehaviour> levelUpActions;
    [SerializeField] private int _level;
    [SerializeField] private int _expLevel;
    private int _exp = 0;

    private void Awake()
    {
        Type = AbilityType.Exp;
    }
    

    public void Execute(int value)
    {
        AddExperiance(value);
    }
    public void AddExperiance(int value)
    {
        _exp += value;
        int expToNextLevel = _expLevel * _level;
        while (_exp >= expToNextLevel)
        {
            _exp -= expToNextLevel;
            LevelUp();
        } 
    }

    public void LevelUp()
    {
        _level++;
        foreach (var action in levelUpActions)
        {
            if (!(action is ILevelUp levelUp)) return;
            levelUp.LevelUp(this, _level);
        }
    }
}
