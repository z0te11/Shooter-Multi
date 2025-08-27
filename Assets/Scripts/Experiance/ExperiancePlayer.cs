using System.Collections.Generic;
using System;
using UnityEngine;

public class ExperiancePlayer: MonoBehaviour, IExp, IType
{
    public Action<int> onPlayerLevelChanged;
    public AbilityType Type { get; set; }
    public List<MonoBehaviour> levelUpActions;
    [SerializeField] private int _level;
    [SerializeField] private int _expLevel;
    private int _exp = 0;

    public int Level
    {
        get { return _level; }
        set { _level = value;
              onPlayerLevelChanged?.Invoke(_level);}
    }

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
        int expToNextLevel = _expLevel * Level;
        while (_exp >= expToNextLevel)
        {
            _exp -= expToNextLevel;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        foreach (var action in levelUpActions)
        {
            if (!(action is ILevelUp levelUp)) return;
            levelUp.LevelUp(this, Level);
        }
    }
}
