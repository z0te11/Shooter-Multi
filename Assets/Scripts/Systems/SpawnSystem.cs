using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnSystem : MonoBehaviour
{
    private ISettings _settings;

    [Inject]
    public void Construct(ISettings settings)
    {
        this._settings = settings;
    }

    public void StartSpawnEnemy()
    {
        if (_settings.Enemy != null) StartCoroutine(WaitAndSpawning(_settings.Enemy, _settings.DelaySpawn));
    }

    private IEnumerator WaitAndSpawning(GameObject go, float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            SpawnUnit(go, Utils.GetRandomPos());
        }
    }

    public void SpawnUnit(GameObject go, Vector3 pos)
    {
        if (!go.GetComponent<Unit>()) return;

        var newUnit = Instantiate(go, pos, Quaternion.identity);
        newUnit.GetComponent<Health>().SetHealth(_settings.HealthEnemy);
        newUnit.GetComponent<DamageAbilityTarget>().SetDamage(_settings.DamageEnemy);

    }

    public GameObject SpawnPlayer(PlayerStats playerStats)
    {
        var newPlayer = Instantiate(_settings.Player, new Vector3(0,0,0), Quaternion.identity);
        newPlayer.GetComponent<PlayerHealth>().SetHealth(playerStats.health);
        newPlayer.GetComponent<ShootAbility>().SetDamage(playerStats.damage);
        return newPlayer;
    }
}
