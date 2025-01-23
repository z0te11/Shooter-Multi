using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISettings
{
    GameObject Player { get; }
    GameObject Enemy { get; }
    int HealthEnemy { get; }
    int DamageEnemy { get; }
    float DelaySpawn { get; }
}
