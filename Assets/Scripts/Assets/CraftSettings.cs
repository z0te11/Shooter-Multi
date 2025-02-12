using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[CreateAssetMenu]
public class CraftSettings : ScriptableObject
{
    public List<CraftCombination> combinations;
}

[Serializable]
public class CraftCombination
{
    public List<string> sources;
    public GameObject result;
}
