using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettings: ISettings
{
    private GameObject _player;
    private GameObject _enemy;

    public DefaultSettings(GameObject player, GameObject enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public GameObject Player => _player;
    public GameObject Enemy => _enemy;
    public int HealthEnemy => 20;
    public int DamageEnemy => 15;
    public float DelaySpawn => 2f;
}
