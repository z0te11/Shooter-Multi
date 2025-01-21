using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject
{
    public GameObject player;
    public GameObject enemy;

    public int healthEnemy;
    public int damageEnemy;
    
    public float delaySpawn;
}
